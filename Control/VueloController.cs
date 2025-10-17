// Control/VueloController.cs
using System;
using DomestikReservas.Datos;
using DomestikReservas.Negocio;

namespace DomestikReservas.Control
{
    public class VueloController
    {
        private VueloService vueloService = new VueloService();

        public void MostrarVuelo(Vuelo vuelo)
        {
            if (!vueloService.ValidarFecha(vuelo.Fecha))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            if (!vueloService.ValidarHora(vuelo.Hora))
            {
                Console.WriteLine("Hora inválida.");
                return;
            }

            if (!vueloService.ValidarDestino(vuelo.Destino))
            {
                Console.WriteLine("Destino inválido.");
                return;
            }

            Console.WriteLine("Vuelo:");
            Console.WriteLine(vuelo);
        }
    }
}
