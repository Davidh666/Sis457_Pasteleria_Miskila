using CadPastelería_Miskila;
using ClnPastelería_Miskila;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CpPastelería_Miskila
{
    public partial class FrmPedidos : Form
    {
        private int idPedidoSeleccionado = 0;

        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            configurarGrilla();
            modoEdicion(false);
            listar();
        }

        // ---------- Utilidades ----------

        private void configurarGrilla()
        {
            colTotal.DefaultCellStyle.Format = "N2";
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFechaPedido.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFechaEntrega.DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        // true = editando un pedido, false = solo consulta
        private void modoEdicion(bool editando)
        {
            gbxDatos.Enabled = editando;
            pnlAcciones.Enabled = !editando;
        }

        private Pedidos pedidoActual()
        {
            return dtgLista.CurrentRow?.DataBoundItem as Pedidos;
        }

        private void listar()
        {
            try
            {
                string parametro = txtParametro.Text.Trim();
                var pedidos = PedidosCln.listar(parametro);
                dtgLista.DataSource = pedidos;

                bool hayDatos = pedidos != null && pedidos.Count > 0;
                btnEditar.Enabled = hayDatos;
                btnEliminar.Enabled = hayDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message, "::: Error - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetearCampos()
        {
            txtCliente.Clear();
            txtObservaciones.Clear();
            txtTotal.Clear();
            cbxTipo.SelectedIndex = -1;
            cbxTipo.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            idPedidoSeleccionado = 0;
            resetearErrores();
        }

        private void resetearErrores()
        {
            erpCliente.Clear();
            erpTipo.Clear();
            erpTotal.Clear();
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
            if (string.IsNullOrWhiteSpace(cbxTipo.Text))
            {
                erpTipo.SetError(cbxTipo, "Seleccione o escriba el tipo de pedido");
                esValido = false;
            }
            if (!decimal.TryParse(txtTotal.Text.Trim(), out decimal total) || total < 0)
            {
                erpTotal.SetError(txtTotal, "Ingrese un total válido");
                esValido = false;
            }

            return esValido;
        }

        // ---------- Búsqueda ----------

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // evita el "beep" al presionar Enter
                listar();
            }
        }

        // ---------- Editar / Guardar / Cancelar ----------

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var pedido = pedidoActual();
            if (pedido == null)
            {
                MessageBox.Show("Seleccione un registro para editar.", "::: Advertencia - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            resetearErrores();
            idPedidoSeleccionado = pedido.id_pedido;

            txtCliente.Text = pedido.Usuarios != null ? pedido.Usuarios.nombre : string.Empty;
            txtObservaciones.Text = pedido.observaciones;
            cbxTipo.Text = pedido.tipo_pedido;
            txtTotal.Text = pedido.total.ToString();
            if (pedido.fecha_entrega.HasValue)
                dateTimePicker1.Value = pedido.fecha_entrega.Value;

            modoEdicion(true);
            txtCliente.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarCampos()) return;

            var pedido = new Pedidos
            {
                id_pedido = idPedidoSeleccionado,
                observaciones = txtObservaciones.Text.Trim(),
                tipo_pedido = cbxTipo.Text.Trim(),
                total = decimal.Parse(txtTotal.Text.Trim()),
                fecha_entrega = dateTimePicker1.Value
            };

            try
            {
                // Antes se enviaba txtCliente.ToString(), que devuelve
                // "System.Windows.Forms.TextBox, Text: ..." y no el nombre.
                PedidosCln.actualizarPedido(pedido, txtCliente.Text.Trim());

                listar();
                cancelarEdicion();
                MessageBox.Show("Pedido guardado correctamente.", "::: Mensaje - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "::: Error - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void cancelarEdicion()
        {
            resetearCampos();
            modoEdicion(false);
        }

        // ---------- Eliminar / Cerrar ----------

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var pedido = pedidoActual();
            if (pedido == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "::: Advertencia - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show("¿Está seguro de que desea eliminar este pedido?",
                "::: Confirmación - Miskila :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes) return;

            try
            {
                PedidosCln.eliminarPedido(pedido.id_pedido);
                listar();
                MessageBox.Show("Pedido eliminado correctamente.", "::: Mensaje - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "::: Error - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ---------- Total: solo números ----------

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            string separador = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (e.KeyChar.ToString() == separador && !txtTotal.Text.Contains(separador)) return;

            e.Handled = true;
        }
    }
}
