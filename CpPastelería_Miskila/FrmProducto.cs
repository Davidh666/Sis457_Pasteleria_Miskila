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
    public partial class FrmProducto : Form
    {
        private bool esNuevo = false;

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var productos = ProductoCln.listar(txtParametro.Text.Trim());
            dgvLista.DataSource = productos;

            if (dgvLista.Columns["id_producto"] != null) dgvLista.Columns["id_producto"].HeaderText = "ID";
            if (dgvLista.Columns["nombre"] != null) dgvLista.Columns["nombre"].HeaderText = "Nombre";
            if (dgvLista.Columns["descripcion"] != null) dgvLista.Columns["descripcion"].HeaderText = "Descripción";
            if (dgvLista.Columns["precio"] != null) dgvLista.Columns["precio"].HeaderText = "Precio (Bs.)";
            if (dgvLista.Columns["disponible"] != null) dgvLista.Columns["disponible"].HeaderText = "Disponible";

            if (dgvLista.Columns["estado"] != null) dgvLista.Columns["estado"].Visible = false;
            if (dgvLista.Columns["DetallePedido"] != null) dgvLista.Columns["DetallePedido"].Visible = false;
            if (dgvLista.Columns["Inventario"] != null) dgvLista.Columns["Inventario"].Visible = false;

            btnEditar.Enabled = productos.Count > 0;
            btnEliminar.Enabled = productos.Count > 0;

            if (productos.Count > 0) dgvLista.Rows[0].Selected = true;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            pnlAcciones.Enabled = true;
            gbxDatos.Enabled = false;
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;
            gbxDatos.Enabled = true;
            limpiar();
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            gbxDatos.Enabled = true;
            txtNombre.Focus();

            int idIndex = dgvLista.CurrentRow.Index;
            int id = Convert.ToInt32(dgvLista.Rows[idIndex].Cells["id_producto"].Value);
            var producto = ProductoCln.obtenerUno(id);

            txtNombre.Text = producto.nombre;
            txtDescripcion.Text = producto.descripcion;
            nudPrecio.Value = producto.precio;
            chkDisponible.Checked = producto.disponible;
        }

        private void limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            nudPrecio.Value = 0;
            chkDisponible.Checked = true;
            erpNombre.Clear();
            erpPrecio.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlAcciones.Enabled = true;
            gbxDatos.Enabled = false;
            limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                listar();
            }
        }

        private bool validar()
        {
            bool esValido = true;
            erpNombre.Clear();
            erpPrecio.Clear();

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                erpNombre.SetError(txtNombre, "El campo Nombre es obligatorio.");
                esValido = false;
            }

            if (nudPrecio.Value <= 0)
            {
                erpPrecio.SetError(nudPrecio, "El Precio debe ser mayor a 0.");
                esValido = false;
            }

            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar()) return;

            var producto = new Productos
            {
                nombre = txtNombre.Text.Trim(),
                descripcion = txtDescripcion.Text.Trim(),
                precio = nudPrecio.Value,
                disponible = chkDisponible.Checked
            };

            try
            {
                if (esNuevo)
                {
                    producto.estado = 1;
                    ProductoCln.crear(producto);
                }
                else
                {
                    int idIndex = dgvLista.CurrentRow.Index;
                    producto.id_producto = Convert.ToInt32(dgvLista.Rows[idIndex].Cells["id_producto"].Value);
                    ProductoCln.actualizar(producto);
                }

                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Producto guardado correctamente.", "::: Pastelería Misk'ila :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "::: Pastelería Misk'ila :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idIndex = dgvLista.CurrentRow.Index;
            int id = Convert.ToInt32(dgvLista.Rows[idIndex].Cells["id_producto"].Value);
            string nombre = dgvLista.Rows[idIndex].Cells["nombre"].Value.ToString();

            DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el producto '{nombre}'?", "::: Pastelería Misk'ila :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    ProductoCln.eliminar(id, "SIS457");
                    listar();
                    MessageBox.Show("Producto eliminado correctamente.", "::: Pastelería Misk'ila :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "::: Pastelería Misk'ila :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gbxBusqueda_Enter(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}