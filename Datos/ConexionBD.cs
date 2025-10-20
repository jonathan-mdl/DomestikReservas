using MySql.Data.MySqlClient;

namespace DomestikReservas.Datos
{
    public class ConexionBD
    {
        private string connectionString = "Server=localhost;Database=domestik;Uid=root;Pwd=;";

        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                conexion.Open();
            }
            catch (MySqlException ex)
            {
                // Aquí puedes loguear o lanzar mensaje
                throw new Exception("Error al conectar a la base de datos: " + ex.Message);
            }

            return conexion;
        }
    }
}
