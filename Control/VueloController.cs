using DomestikReservas.Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace DomestikReservas.Control
{
    public class VueloController
    {
        public bool AgregarVuelo(Vuelo v)
        {
            string query = "INSERT INTO vuelo (numvlo, fecha, hora, destino) VALUES (@numvlo, @fecha, @hora, @destino)";

            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@numvlo", v.NumVuelo);
                cmd.Parameters.AddWithValue("@fecha", v.Fecha);
                cmd.Parameters.AddWithValue("@hora", v.Hora);
                cmd.Parameters.AddWithValue("@destino", v.Destino);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

        public DataTable ObtenerTodosVuelos()
        {
            string query = "SELECT * FROM vuelo";

            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool ModificarFechaVuelo(string numVlo, DateTime nuevaFecha)
        {
            string query = "UPDATE vuelo SET fecha = @nuevaFecha WHERE numvlo = @numVlo";

            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);
                cmd.Parameters.AddWithValue("@numVlo", numVlo);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException)
                {
                    return false;
                }
            }
        }

    }
}
