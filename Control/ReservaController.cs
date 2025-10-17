// Control/ReservaController.cs
using System;
using DomestikReservas.Datos;
using DomestikReservas.Negocio;

namespace DomestikReservas.Control
{
    public class ReservaController
    {
        private ReservaService reservaService = new ReservaService();

        public Reserva CrearReserva(string codigo, string tipo, string rut, string numVlo, string tipoPasajero)
        {
            double costo = reservaService.CalcularCosto(tipo);
            int puntaje = reservaService.CalcularPuntaje(tipo, tipoPasajero);
            string condicion = reservaService.ObtenerCondicionReserva(tipo);

            Reserva nuevaReserva = new Reserva(codigo, tipo, costo, rut, numVlo);

            Console.WriteLine("Reserva creada:");
            Console.WriteLine(nuevaReserva);
            Console.WriteLine("Condición de reserva: " + condicion);
            Console.WriteLine("Puntaje asignado: " + puntaje);

            return nuevaReserva;
        }
    }
}
