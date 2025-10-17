using System;

namespace DomestikReservas.Datos
{
    public class Pasajero
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }  
        public int Puntaje { get; set; }

        public Pasajero() { }

        public Pasajero(string rut, string nombre, string apellido, string tipo, int puntaje)
        {
            Rut = rut;
            Nombre = nombre;
            Apellido = apellido;
            Tipo = tipo;
            Puntaje = puntaje;
        }

        public override string ToString()
        {
            return $"RUT: {Rut}, Nombre: {Nombre} {Apellido}, Tipo: {Tipo}, Puntaje: {Puntaje}";
        }
    }
}
