using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrarUsuarios.Clases
{
    internal class CIngresarUsuario
    {
        public void login(TextBox txtUsuario, TextBox txtContrasenha)
        {
            CConexion objeto = new CConexion();
            MySqlConnection conex = objeto.establecerConexion();
            conex.Open();

            try
            {
                string sql = "SELECT Usuario, Contraseña FROM usuarios " +
                     "WHERE Usuario = @usuario AND Contraseña = @contraseña";

                MySqlCommand cmd = new MySqlCommand(sql, conex);
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contraseña", txtContrasenha.Text);

                MySqlDataReader rdr = cmd.ExecuteReader();

                if( rdr.Read() )
                {
                    Usuarios us = new Usuarios();
                    Form1 F = new Form1();
                    F.Hide();
                    us.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar el USUARIO en la base de datos" +
                    "Error: " + ex);
            }
            finally
            { 
                conex.Close();
                conex.Dispose();
            }

        }
    }
}
