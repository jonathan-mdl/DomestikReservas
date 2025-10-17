// Program.cs
using System;
using DomestikReservas.Datos;
using DomestikReservas.Control;

namespace DomestikReservas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear datos
            Pasajero pasajero = new Pasajero("12345678-9", "Juan", "Pérez", "Frecuente", 0);
            Vuelo vuelo = new Vuelo("AB12345678", DateTime.Today.AddDays(2), new TimeSpan(15, 30, 0), "Santiago");
            ReservaController reservaController = new ReservaController();
            PasajeroController pasajeroController = new PasajeroController();
            VueloController vueloController = new VueloController();

            // Mostrar datos
            pasajeroController.MostrarPasajero(pasajero);
            vueloController.MostrarVuelo(vuelo);

            // Crear reserva
            Reserva reserva = reservaController.CrearReserva("R0001", "Ejecutivo", pasajero.Rut, vuelo.NumVuelo, pasajero.Tipo);
        }
    }
}
