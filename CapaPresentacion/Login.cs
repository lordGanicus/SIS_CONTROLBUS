using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Formulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreChofer = txt_NombreUsuario.Text;
                string cedula = txt_Contrasena.Text;

                // Instanciar un objeto de la capa de negocio para manejar los choferes
                N_Chofer nChofer = new N_Chofer();

                // Buscar al chofer por su nombre (usuario)
                E_Chofer chofer = nChofer.BuscarPorNombre(nombreChofer);

                if (chofer != null && chofer.CEDULA == cedula)
                {
                    // Si el chofer existe y la cédula coincide, abre la ventana de administración
                    Administrar_Choferes ventanaAdmin = new Administrar_Choferes();
                    ventanaAdmin.Show();
                    this.Hide(); // Oculta la ventana de inicio de sesión
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas. Inténtalo de nuevo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_NombreUsuario.Text = "";
            txt_Contrasena.Text = "";
        }
    }
}
