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
        public bool login (TextBox txtUsuario, TextBox txtContrasenha)
        {
            CConexion objeto = new CConexion();
            MySqlConnection conex = objeto.establecerConexion();
            conex.Open();

            try
            {
                string sql = "SELECT Usuario, Contraseña FROM usuarios " +
                     "WHERE Usuario = @usuario AND Contraseña = SHA2(@contraseña,256)";

                MySqlCommand cmd = new MySqlCommand(sql, conex);
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contraseña", txtContrasenha.Text);

                MySqlDataReader rdr = cmd.ExecuteReader();

                bool valido = rdr.Read();

                rdr.Close();
                return valido;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al comprobar el USUARIO en la base de datos");
                MessageBox.Show("Error: " + ex);
                return false;
            }
            finally
            { 
                conex.Close();
                conex.Dispose();
            }

        }
    }
}
