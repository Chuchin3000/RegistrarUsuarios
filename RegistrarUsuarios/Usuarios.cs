using MySql.Data.MySqlClient;
using RegistrarUsuarios.Clases;
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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            Clases.CAgregarUsuario CA = new Clases.CAgregarUsuario();
            CA.mostrarUsuarios(gridUsuarios);
            txtContrasenha.PasswordChar = '*';
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Clases.CAgregarUsuario CA = new Clases.CAgregarUsuario();
            if(txtNombre.Text == "" || txtApellidos.Text == "" || txtContrasenha.Text == "" || 
                txtUsuario.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Debes llenar todos los campos");
            }
            else if( CA.Agregar(txtNombre,txtApellidos,txtUsuario,txtContrasenha,txtEmail) is true)
            {
                CA.mostrarUsuarios(gridUsuarios);
                txtNombre.Clear();
                txtApellidos.Clear();
                txtUsuario.Clear();
                txtContrasenha.Clear();
                txtEmail.Clear();
                MessageBox.Show("El usuario se agregó exitosamente :D");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 fo = new Form1();
            this.Hide();
            fo.Show();
        }

        private void Usuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
