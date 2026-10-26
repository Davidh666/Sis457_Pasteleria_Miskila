using System;
using System.Windows.Forms;

namespace CpPastelería_Miskila
{
    public partial class FrmPrincipal : Form
    {
        private readonly string rolUsuario;
        private readonly string nombreUsuario;

        public FrmPrincipal(string rol, string nombre)
        {
            InitializeComponent();

            this.rolUsuario = rol;
            this.nombreUsuario = nombre;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = $"CpPastelería_Miskila - Menú Principal | Usuario: {nombreUsuario} ({rolUsuario})";
            AplicarPermisosPorRol();
        }

        private void AplicarPermisosPorRol()
        {
            string rolLimpio = rolUsuario != null ? rolUsuario.Trim().ToLower() : string.Empty;

            // Solo el administrador ve la gestión de usuarios
            btnUsuarios.Visible = (rolLimpio == "administrador" || rolLimpio == "admin");
        }

        // Abre un formulario hijo de forma modal y lo libera al cerrarse
        private void AbrirFormulario(Form frm)
        {
            using (frm)
            {
                frm.ShowDialog(this);
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProducto());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmUsuarios());
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmPedidos());
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            // TODO: abrir aquí el formulario de nueva venta cuando exista
            MessageBox.Show("Este módulo aún no está disponible.", "::: Miskila :::",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            // TODO: abrir aquí el formulario de pagos cuando exista
            MessageBox.Show("Este módulo aún no está disponible.", "::: Miskila :::",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Desea cerrar sesión y salir del sistema?",
                "::: Confirmación - Miskila :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Nombre: {nombreUsuario}\nRol: {rolUsuario}", "Mi perfil",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
