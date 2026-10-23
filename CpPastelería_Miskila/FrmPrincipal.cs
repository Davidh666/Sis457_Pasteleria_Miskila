using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadPastelería_Miskila;

namespace CpPastelería_Miskila
{
    public partial class FrmPrincipal : Form
    {
        private string rolUsuario;
        private string nombreUsuario;

        public FrmPrincipal(string rol, string nombre)
        {
            InitializeComponent();
            // this.IsMdiContainer = true;
            this.rolUsuario = rol;
            this.nombreUsuario = nombre;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = $"CpPastelería_Miskila - Menú Principal | Usuario: {nombreUsuario} ({rolUsuario})";
            AplicarPermisosPorRol();
            Centrado();
            btnPerfil.Text = nombreUsuario;

        }

        private void AplicarPermisosPorRol()
        {
            string rolLimpio = rolUsuario.Trim().ToLower();

            if (rolLimpio == "administrador" || rolLimpio == "admin")
            {
                btnUsuarios.Visible = true;
            }
            else
            {
                btnUsuarios.Visible = false;
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProducto frm = new FrmProducto();
            frm.Show(); 
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Usuario conectado: {nombreUsuario}\nRol: {rolUsuario}", "Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void Centrado()
        {
           
            int ancho_forma = this.ClientSize.Width;
            int altura_forma = this.ClientSize.Height;

            int ancho_group = contenedor.Width;
            int altura_group = contenedor.Height;

           
            int nuevaAnch = (ancho_forma - ancho_group) / 2;
            int nuevaAlt = (altura_forma - altura_group) / 2;

            contenedor.Location = new Point(nuevaAnch, nuevaAlt);

            int margenDerecho = 40;
            int margenSuperior = 40;
            btnPerfil.Location = new Point(this.ClientSize.Width - btnPerfil.Width - margenDerecho, margenSuperior);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos frm = new FrmPedidos();
            frm.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
        
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}