using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrarUsuarios.Clases
{
    internal class CConexion
    {
        MySqlConnection conex = new MySqlConnection();

        static String server = "localhost";
        static String db = "proyectousuarios";
        static String user = "root";
        static String password = "chuchin";
        static String port = "3306";

        String cadenaConexion = "server=" + server + ";port=" + port + ";user id=" + user + ";password=" + password + ";database=" + db + ";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                //conex.Open();
                //MessageBox.Show("Se logró conectar a la base de datos correctamente :D");
                //conex.Close();
                //conex.Dispose();

            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se pudo conectar a la Base de Datos, error: " + e.ToString());
            }

            return conex;
        }
    }
}
