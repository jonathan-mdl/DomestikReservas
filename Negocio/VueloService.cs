// Negocio/VueloService.cs
using System;

namespace DomestikReservas.Negocio
{
    public class VueloService
    {
        // Validar que la fecha no sea anterior a hoy
        public bool ValidarFecha(DateTime fecha)
        {
            return fecha >= DateTime.Today;
        }

        // Validar que la hora esté en formato correcto (usualmente TimeSpan ya lo garantiza)
        public bool ValidarHora(TimeSpan hora)
        {
            return hora.TotalMinutes >= 0 && hora.TotalMinutes < 1440;
        }

        // Validar destino (no vacío, menos de 30 caracteres)
        public bool ValidarDestino(string destino)
        {
            return !string.IsNullOrWhiteSpace(destino) && destino.Length <= 30;
        }
    }
}
