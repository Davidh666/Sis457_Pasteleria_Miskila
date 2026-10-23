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
    public partial class FrmUsuarios : Form
    {
        private bool esNuevo;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void listar()
        {
            try
            {
                string parametro = (txtParametro != null) ? txtParametro.Text.Trim() : string.Empty;
                var usuarios = UsuarioCln.listar(parametro);

                dataGridView1.DataSource = usuarios;

                if (dataGridView1.Columns["id_usuario"] != null) dataGridView1.Columns["id_usuario"].Visible = false;
                if (dataGridView1.Columns["Id_Usuario"] != null) dataGridView1.Columns["Id_Usuario"].Visible = false;

                if (dataGridView1.Columns["contrasena_hash"] != null) dataGridView1.Columns["contrasena_hash"].Visible = false;
                if (dataGridView1.Columns["Contrasena_Hash"] != null) dataGridView1.Columns["Contrasena_Hash"].Visible = false;

                if (dataGridView1.Columns["estado"] != null) dataGridView1.Columns["estado"].Visible = false;
                if (dataGridView1.Columns["Estado"] != null) dataGridView1.Columns["Estado"].Visible = false;

                if (dataGridView1.Columns["nombre"] != null) dataGridView1.Columns["nombre"].HeaderText = "Nombre";
                if (dataGridView1.Columns["Nombre"] != null) dataGridView1.Columns["Nombre"].HeaderText = "Nombre";

                if (dataGridView1.Columns["celular"] != null) dataGridView1.Columns["celular"].HeaderText = "Celular";
                if (dataGridView1.Columns["Celular"] != null) dataGridView1.Columns["Celular"].HeaderText = "Celular";

                if (dataGridView1.Columns["email"] != null) dataGridView1.Columns["email"].HeaderText = "Email";
                if (dataGridView1.Columns["Email"] != null) dataGridView1.Columns["Email"].HeaderText = "Email";

                if (dataGridView1.Columns["rol"] != null) dataGridView1.Columns["rol"].HeaderText = "Rol";
                if (dataGridView1.Columns["Rol"] != null) dataGridView1.Columns["Rol"].HeaderText = "Rol";

                
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (usuarios != null && usuarios.Count > 0)
                {
                    if (dataGridView1.Columns["nombre"] != null)
                        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["nombre"];
                    else if (dataGridView1.Columns["Nombre"] != null)
                        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["Nombre"];

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

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'labPastelería_MiskilaDataSet.Pedidos' Puede moverla o quitarla según sea necesario.
            this.pedidosTableAdapter.Fill(this.labPastelería_MiskilaDataSet.Pedidos);
            pnlAcciones.Enabled = true;
            gbxDatos.Enabled = false;
            listar();
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
            txtNombre.Clear();
            txtEmail.Clear();
            txtCelular.Clear();
            txtContrasena.Clear();
            if (cbxRol.Items.Count > 0) cbxRol.SelectedIndex = -1;
            resetearErrores();
        }

        private void resetearErrores()
        {
            erpNombre.Clear();
            erpEmail.Clear();
            erpCelular.Clear();
            erpRol.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            
            pnlAcciones.Enabled = false;
            gbxDatos.Enabled = true;
            resetearCampos();
            txtNombre.Focus();
            if (cbxRol.Items.Count > 0) cbxRol.SelectedIndex = -1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                esNuevo = false;
               
                pnlAcciones.Enabled = false;
                gbxDatos.Enabled = true;

                int id = (int)dataGridView1.CurrentRow.Cells["id_usuario"].Value;
                var usuario = UsuarioCln.obtenerUsuario(id);
                if (usuario != null)
                {
                    txtNombre.Text = usuario.nombre;
                    txtEmail.Text = usuario.email;
                    txtCelular.Text = usuario.celular;
                    cbxRol.Text = usuario.rol;
                    txtContrasena.Clear();
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
            gbxDatos.Enabled = false;
            resetearCampos();
        }

        private bool validarCampos()
        {
            bool esValido = true;
            resetearErrores();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                erpEmail.SetError(txtEmail, "El email es obligatorio");
                esValido = false;
            }
            if (cbxRol.SelectedIndex == -1)
            {
                erpRol.SetError(cbxRol, "Debe seleccionar un rol");
                esValido = false;
            }

            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                var usuario = new Usuarios
                {
                    nombre = txtNombre.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    celular = txtCelular.Text.Trim(),
                    rol = cbxRol.Text,
                    contrasena_hash = txtContrasena.Text.Trim()
                };

                try
                {
                    if (esNuevo)
                    {
                        UsuarioCln.crearUsuario(usuario);
                    }
                    else
                    {
                        usuario.id_usuario = (int)dataGridView1.CurrentRow.Cells["id_usuario"].Value;
                        UsuarioCln.actualizarUsuario(usuario);
                    }
                    listar();
                    btnCancelar.PerformClick();
                    MessageBox.Show("Usuario guardado correctamente", "::: Mensaje - Miskila :::",
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
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["id_usuario"].Value;
                string nombre = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                DialogResult dialog = MessageBox.Show($"¿Está seguro que desea dar de baja al usuario {nombre}?",
                    "::: Confirmación - Miskila :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    UsuarioCln.eliminarUsuario(id);
                    listar();
                    MessageBox.Show("Usuario dado de baja correctamente", "::: Mensaje - Miskila :::",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void cont1_Enter(object sender, EventArgs e) { }

        private void cont2_Enter(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método requerido por el diseñador visual
        }
    }
}