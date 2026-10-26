using CadPastelería_Miskila;
using ClnPastelería_Miskila;
using System;
using System.Net.Mail;
using System.Windows.Forms;

namespace CpPastelería_Miskila
{
    public partial class FrmUsuarios : Form
    {
        private bool esNuevo;
        private int idUsuarioSeleccionado = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            modoEdicion(false);
            listar();
        }

        // ---------- Utilidades ----------

        // true = capturando datos (nuevo / editar), false = solo consulta
        private void modoEdicion(bool editando)
        {
            gbxDatos.Enabled = editando;
            pnlAcciones.Enabled = !editando;
        }

        // Id del usuario seleccionado en la grilla (null si no hay selección).
        // Se lee por la columna del diseñador, no por un nombre de texto.
        private int? idUsuarioActual()
        {
            if (dtgLista.CurrentRow == null) return null;
            object valor = dtgLista.CurrentRow.Cells[colId.Index].Value;
            return valor == null ? (int?)null : Convert.ToInt32(valor);
        }

        private void listar()
        {
            try
            {
                string parametro = txtParametro.Text.Trim();
                var usuarios = UsuarioCln.listar(parametro);
                dtgLista.DataSource = usuarios;

                bool hayDatos = usuarios != null && usuarios.Count > 0;
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
            txtNombre.Clear();
            txtEmail.Clear();
            txtCelular.Clear();
            txtContrasena.Clear();
            cbxRol.SelectedIndex = -1;
            idUsuarioSeleccionado = 0;
            resetearErrores();
        }

        private void resetearErrores()
        {
            erpNombre.Clear();
            erpEmail.Clear();
            erpCelular.Clear();
            erpRol.Clear();
            erpContrasena.Clear();
        }

        private static bool emailValido(string email)
        {
            try
            {
                var direccion = new MailAddress(email);
                return direccion.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
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

            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                erpEmail.SetError(txtEmail, "El email es obligatorio");
                esValido = false;
            }
            else if (!emailValido(email))
            {
                erpEmail.SetError(txtEmail, "Ingrese un email válido");
                esValido = false;
            }

            if (cbxRol.SelectedIndex == -1)
            {
                erpRol.SetError(cbxRol, "Debe seleccionar un rol");
                esValido = false;
            }

            // Para un usuario nuevo la contraseña es obligatoria
            if (esNuevo && string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                erpContrasena.SetError(txtContrasena, "La contraseña es obligatoria");
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
                e.Handled = true;
                listar();
            }
        }

        // ---------- Nuevo / Editar / Guardar / Cancelar ----------

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            resetearCampos();
            modoEdicion(true);
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = idUsuarioActual();
            if (id == null)
            {
                MessageBox.Show("Seleccione un registro para editar.", "::: Advertencia - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuario = UsuarioCln.obtenerUsuario(id.Value);
                if (usuario == null)
                {
                    MessageBox.Show("No se encontró el usuario seleccionado.", "::: Advertencia - Miskila :::",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                esNuevo = false;
                resetearErrores();
                idUsuarioSeleccionado = id.Value;

                txtNombre.Text = usuario.nombre;
                txtEmail.Text = usuario.email;
                txtCelular.Text = usuario.celular;
                cbxRol.SelectedIndex = cbxRol.FindStringExact(usuario.rol ?? string.Empty);
                txtContrasena.Clear();

                modoEdicion(true);
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el usuario: " + ex.Message, "::: Error - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validarCampos()) return;

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
                    usuario.id_usuario = idUsuarioSeleccionado;
                    UsuarioCln.actualizarUsuario(usuario);
                }

                listar();
                cancelarEdicion();
                MessageBox.Show("Usuario guardado correctamente.", "::: Mensaje - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "::: Error - Miskila :::",
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
            int? id = idUsuarioActual();
            if (id == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "::: Advertencia - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = Convert.ToString(dtgLista.CurrentRow.Cells[colNombre.Index].Value);
            var dialogo = MessageBox.Show($"¿Está seguro que desea dar de baja al usuario {nombre}?",
                "::: Confirmación - Miskila :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo != DialogResult.Yes) return;

            try
            {
                UsuarioCln.eliminarUsuario(id.Value);
                listar();
                MessageBox.Show("Usuario dado de baja correctamente.", "::: Mensaje - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja: " + ex.Message, "::: Error - Miskila :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ---------- Celular: solo dígitos ----------

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
