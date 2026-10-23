using CadPastelería_Miskila;
using ClnPastelería_Miskila;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpPastelería_Miskila
{
    public partial class FrmPedidos : Form
    {
        private bool esNuevo;

        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void listar()
        {
            try
            {
                string parametro = (txtParametro != null) ? txtParametro.Text.Trim() : string.Empty;
                var pedidos = PedidosCln.listar(parametro);
                dtgLista.DataSource = pedidos;

                if (dtgLista.Columns["id_pedido"] != null) dtgLista.Columns["id_pedido"].Visible = false;
                if (dtgLista.Columns["id_usuario"] != null) dtgLista.Columns["id_usuario"].Visible = false;
                if (dtgLista.Columns["estado"] != null) dtgLista.Columns["estado"].Visible = false;

                dtgLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (pedidos != null && pedidos.Count > 0)
                {
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
                else
                {
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            gbxDatos.Enabled = false; // Bloquea los campos al iniciar
            pnlAcciones.Enabled = true;
            listar();
        }

        // Método puente por si el diseñador busca FrmPedidos_Load_1
        private void FrmPedidos_Load_1(object sender, EventArgs e)
        {
            FrmPedidos_Load(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void resetearCampos()
        {
            txtCliente.Clear();
            txtObservaciones.Clear();
            txtTotal.Clear();
            if (cbxTipo.Items.Count > 0) cbxTipo.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            resetearErrores();
        }

        private void resetearErrores()
        {
            erpCliente.Clear();
            erpTipo.Clear();
            erpTotal.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;
            gbxDatos.Enabled = true; // Habilita los campos solo al dar nuevo
            resetearCampos();
            txtCliente.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgLista.CurrentRow != null)
            {
                esNuevo = false;
                pnlAcciones.Enabled = false;
                gbxDatos.Enabled = true; // Habilita los campos al editar

                int id = Convert.ToInt32(dtgLista.CurrentRow.Cells["id_pedido"].Value);
                var pedido = PedidosCln.obtenerPedido(id);
                if (pedido != null)
                {
                    txtCliente.Text = pedido.Usuarios != null ? pedido.Usuarios.nombre : string.Empty;
                    txtObservaciones.Text = pedido.observaciones;
                    cbxTipo.Text = pedido.tipo_pedido;
                    txtTotal.Text = pedido.total.ToString();
                    dateTimePicker1.Value = pedido.fecha_entrega ?? DateTime.Now;
                }
            }
            else
            {
                MessageBox.Show("Seleccione un registro para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlAcciones.Enabled = true;
            gbxDatos.Enabled = false; // Vuelve a bloquear los campos al cancelar
            resetearCampos();
        }

        private bool validarCampos()
        {
            bool esValido = true;
            resetearErrores();

            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                erpCliente.SetError(txtCliente, "El cliente es obligatorio");
                esValido = false;
            }
            if (cbxTipo.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cbxTipo.Text))
            {
                erpTipo.SetError(cbxTipo, "Seleccione o escriba el tipo de pedido");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtTotal.Text) || !decimal.TryParse(txtTotal.Text, out _))
            {
                erpTotal.SetError(txtTotal, "Ingrese un total válido");
                esValido = false;
            }

            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                string nombreCliente = txtCliente.Text.Trim();

                var pedido = new Pedidos
                {
                    observaciones = txtObservaciones.Text.Trim(),
                    tipo_pedido = cbxTipo.Text,
                    total = Convert.ToDecimal(txtTotal.Text.Trim()),
                    fecha_entrega = dateTimePicker1.Value
                };

                try
                {
                    if (esNuevo)
                    {
                        PedidosCln.crearPedido(pedido);
                    }
                    else
                    {
                        pedido.id_pedido = Convert.ToInt32(dtgLista.CurrentRow.Cells["id_pedido"].Value);
                        PedidosCln.actualizarPedido(pedido);
                    }
                    listar();
                    btnCancelar.PerformClick();
                    MessageBox.Show("Pedido guardado correctamente", "::: Mensaje - Miskila :::",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "::: Error - Miskila :::",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtgLista.CurrentRow != null)
            {
                int id = Convert.ToInt32(dtgLista.CurrentRow.Cells["id_pedido"].Value);

                DialogResult dialog = MessageBox.Show($"¿Está seguro que desea dar de baja el pedido?",
                    "::: Confirmación - Miskila :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    PedidosCln.eliminarPedido(id);
                    listar();
                    MessageBox.Show("Pedido dado de baja correctamente", "::: Mensaje - Miskila :::",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}