// Negocio/ReservaService.cs
using System;

namespace DomestikReservas.Negocio
{
    public class ReservaService
    {
        // Método que calcula el costo del pasaje según el tipo
        public double CalcularCosto(string tipoReserva)
        {
            switch (tipoReserva.ToLower())
            {
                case "económica":
                    return 30000 + 5500;
                case "turista":
                    return 40000 + 6000;
                case "ejecutivo":
                    return 60000 + 10000;
                default:
                    return 0;
            }
        }

        // Método que determina la condición de la reserva según el tipo
        public string ObtenerCondicionReserva(string tipoReserva)
        {
            switch (tipoReserva.ToLower())
            {
                case "económica":
                    return "No sujeta a cambio.";
                case "turista":
                    return "Para cambio debe pagar 10% del valor base.";
                case "ejecutivo":
                    return "Puede efectuar cambio sin costo.";
                default:
                    return "Tipo de reserva no válido.";
            }
        }

        // Método que calcula puntaje solo si el pasajero es frecuente
        public int CalcularPuntaje(string tipoReserva, string tipoPasajero)
        {
            if (tipoPasajero.ToLower() != "frecuente")
                return 0;

            switch (tipoReserva.ToLower())
            {
                case "económica":
                    return 500;
                case "turista":
                    return 700;
                case "ejecutivo":
                    return 1000;
                default:
                    return 0;
            }
        }
    }
}
