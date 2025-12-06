using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrarUsuarios
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtContrasenha.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clases.CIngresarUsuario CI = new Clases.CIngresarUsuario();

            if( CI.login(txtUsuario, txtContrasenha) is true )
            {
                this.Hide();
                Usuarios us = new Usuarios();
                us.Show();
                ;
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta");
            }
            
        }
    }
}
