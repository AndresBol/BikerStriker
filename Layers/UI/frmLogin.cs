using BikerStriker.Extensions;
using BikerStriker.Interfaces;
using BikerStriker.Layers.BLL;
using BikerStriker.Layers.Entities;
using BikerStriker.Properties;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStriker.Layers.UI
{
    public partial class frmLogin : Form
    {

        private static readonly ILog _Logger = log4net.LogManager.GetLogger("MyControlEventos");
        private int contador = 0;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }


        private void LogIn()
        {
            // Debe validar los datos requeridos
            IBLLUsuario _BLLUsuario = new BLLUsuario();
            epError.Clear();
            Usuario oUsuario = null;
            try
            {

                if (string.IsNullOrEmpty(this.txtLogin.Text))
                {
                    epError.SetError(txtLogin, "Correo requerido");
                    this.txtLogin.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    epError.SetError(txtPassword, "Contraseña requerida");
                    this.txtPassword.Focus();
                    return;
                }

                oUsuario = _BLLUsuario.Login(this.txtLogin.Text, this.txtPassword.Text);

                if (oUsuario == null)
                {
                    ++contador;
                    MessageBox.Show("Error en el acceso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Si el contador es 3 cierre la aplicación
                    if (contador == 3)
                    {
                        // se devuelve Cancel
                        MessageBox.Show("Se equivocó en 3 ocasiones, el Sistema se Cerrará por seguridad", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _Logger.WarnFormat("Se equivocó + de 3 ocasiones Login: {0}", this.txtLogin.Text);
                        this.DialogResult = DialogResult.Cancel;
                        Application.Exit();
                    }
                }
                else
                {

                    Settings.Default.Correo = oUsuario.Correo;
                    Settings.Default.Contrasena = oUsuario.Contraseña;
                    Settings.Default.Nombre = oUsuario.Nombre;
                    Settings.Default.TipoUsuario = oUsuario.TipoUsuario;

                    // Log de errores
                    _Logger.InfoFormat("Accedió a la aplicación :{0}", Settings.Default.Nombre);
                    this.DialogResult = DialogResult.OK;

                }
            }
            catch (Exception er)
            {
                string msg = "";
                _Logger.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
