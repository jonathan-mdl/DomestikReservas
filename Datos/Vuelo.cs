// Datos/Vuelo.cs
using System;

namespace DomestikReservas.Datos
{
    public class Vuelo
    {
        public string NumVuelo { get; set; } 
        public DateTime Fecha { get; set; }  // dd-mm-aaaa
        public TimeSpan Hora { get; set; }   
        public string Destino { get; set; }  

        public Vuelo() { }

        public Vuelo(string numVuelo, DateTime fecha, TimeSpan hora, string destino)
        {
            NumVuelo = numVuelo;
            Fecha = fecha;
            Hora = hora;
            Destino = destino;
        }

        public override string ToString()
        {
            return $"N° Vuelo: {NumVuelo}, Fecha: {Fecha.ToShortDateString()}, Hora: {Hora}, Destino: {Destino}";
        }
    }
}
