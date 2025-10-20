using DomestikReservas.Datos;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace DomestikReservas.Control
{
    public class PasajeroController
    {
        public bool AgregarPasajero(Pasajero p)
        {
            string query = "INSERT INTO pasajero (rut, nombre, apellido, tipo, puntaje) VALUES (@rut, @nombre, @apellido, @tipo, @puntaje)";

            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@rut", p.Rut);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellido", p.Apellido);
                cmd.Parameters.AddWithValue("@tipo", p.Tipo);
                cmd.Parameters.AddWithValue("@puntaje", p.Puntaje);

                try
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex)
                {
                    // Aquí puedes mostrar mensaje si quieres
                    return false;
                }
            }
        }

        public DataTable ObtenerTodosPasajeros()
        {
            string query = "SELECT * FROM pasajero";

            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
