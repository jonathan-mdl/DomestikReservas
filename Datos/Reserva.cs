// Datos/Reserva.cs
using System;

namespace DomestikReservas.Datos
{
    public class Reserva
    {
        public string Codigo { get; set; } 
        public string Tipo { get; set; }  
        public double Valor { get; set; }   
        public string Rut { get; set; }
        public string NumVlo { get; set; }  

        public Reserva() { }

        public Reserva(string codigo, string tipo, double valor, string rut, string numVlo)
        {
            Codigo = codigo;
            Tipo = tipo;
            Valor = valor;
            Rut = rut;
            NumVlo = numVlo;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Tipo: {Tipo}, Valor: {Valor}, Rut: {Rut}, n° de Vuelo: {numVlo}";
        }
    }
}
