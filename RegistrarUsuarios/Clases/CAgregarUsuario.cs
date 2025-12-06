using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrarUsuarios.Clases
{
    internal class CAgregarUsuario
    { 
        public bool Agregar(TextBox txtNombre, TextBox txtApellidos, TextBox txtUsuario, 
            TextBox txtContraseña, TextBox txtEmail)
        {
            CConexion objetoConexion = new CConexion();
            MySqlConnection conn = objetoConexion.establecerConexion();
            conn.Open();

            try
            {
                String sql = "INSERT INTO usuarios (Nombres,Apellidos,Usuario,Contraseña,Email) " +
                    "VALUES(@Nombre,@Apellidos,@Usuario,SHA2(@Contraseña,256),@Email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                cmd.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@Contraseña", txtContraseña.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Close();
                cmd.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo Agregar el usuario ");
                MessageBox.Show("Error: " + ex.ToString());
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void mostrarUsuarios(DataGridView gridUsuarios)
        {
            CConexion objetoConexion = new CConexion();
            MySqlConnection conn = objetoConexion.establecerConexion();
            conn.Open();
            try
            {
                String sql = "select * From usuarios";

                gridUsuarios.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridUsuarios.DataSource = dt;

                dt.Dispose();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar la tabla Products");
                MessageBox.Show("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
