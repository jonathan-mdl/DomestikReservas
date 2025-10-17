// Negocio/PasajeroService.cs
using System;
using System.Text.RegularExpressions;

namespace DomestikReservas.Negocio
{
    public class PasajeroService
    {
        // Validar nombre y apellido (mínimo un nombre y un apellido)
        public bool ValidarNombreCompleto(string nombre, string apellido)
        {
            return !string.IsNullOrWhiteSpace(nombre) &&
                   !string.IsNullOrWhiteSpace(apellido) &&
                   nombre.Trim().Contains(" ") == false &&
                   apellido.Trim().Contains(" ") == false;
        }

        // Validar que el rut tenga 10 caracteres y contenga guión
        public bool ValidarRut(string rut)
        {
            if (string.IsNullOrWhiteSpace(rut)) return false;
            return rut.Length == 10 && rut.Contains("-");
        }
    }
}
