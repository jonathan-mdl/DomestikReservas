using DomestikReservas.Datos;
using DomestikReservas.Negocio;
using MySql.Data.MySqlClient;
using System.Data;

namespace DomestikReservas.Control
{
    public class ReservaController
    {
        private ReservaService reservaService = new ReservaService();

        public bool AgregarReserva(Reserva r)
        {
            string query = "INSERT INTO reserva (codigo, tipo_reserva, valor, rut, numvlo) VALUES (@codigo, @tipo, @valor, @rut, @numvlo)";

            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@codigo", r.Codigo);
                cmd.Parameters.AddWithValue("@tipo", r.TipoReserva);
                cmd.Parameters.AddWithValue("@valor", r.Valor);
                cmd.Parameters.AddWithValue("@rut", r.Rut);
                cmd.Parameters.AddWithValue("@numvlo", r.NumVlo);

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

        public DataTable ObtenerReservasConDetalle()
        {
            string query = "SELECT * FROM reserva";

            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Agregar columnas extra
                dt.Columns.Add("condicion_reserva", typeof(string));
                dt.Columns.Add("puntaje_acumulado", typeof(int));

                ReservaService reservaService = new ReservaService();
                foreach (DataRow row in dt.Rows)
                {
                    string tipo = row["tipo_reserva"].ToString();
                    string tipoPasajero = "Frecuente"; // Simulado
                    row["condicion_reserva"] = reservaService.ObtenerCondicionReserva(tipo);
                    row["puntaje_acumulado"] = reservaService.CalcularPuntaje(tipo, tipoPasajero);
                }

                return dt;
            }
    
        }

        public bool ModificarFechaReserva(string codigo, DateTime nuevaFecha)
        {
            string query = "UPDATE reserva SET fecha = @nuevaFecha WHERE codigo = @codigo";
            using (MySqlConnection conn = new ConexionBD().ObtenerConexion())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);
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
