// Control/PasajeroController.cs
using System;
using DomestikReservas.Datos;
using DomestikReservas.Negocio;

namespace DomestikReservas.Control
{
    public class PasajeroController
    {
        private PasajeroService pasajeroService = new PasajeroService();

        public void MostrarPasajero(Pasajero pasajero)
        {
            if (!pasajeroService.ValidarNombreCompleto(pasajero.Nombre, pasajero.Apellido))
            {
                Console.WriteLine("Nombre o apellido inválido.");
                return;
            }

            if (!pasajeroService.ValidarRut(pasajero.Rut))
            {
                Console.WriteLine("RUT inválido.");
                return;
            }

            Console.WriteLine("Pasajero:");
            Console.WriteLine(pasajero);
        }
    }
}
