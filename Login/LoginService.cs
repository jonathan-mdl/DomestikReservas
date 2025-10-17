// Login/LoginService.cs
using System;
using System.Collections.Generic;

namespace DomestikReservas.Login
{
    public class LoginService
    {
        private Dictionary<string, string> usuarios = new Dictionary<string, string>()
        {
            { "admin", "1234" },
            { "usuario1", "abcd" }
        };

        public bool ValidarLogin(string usuario, string contraseña)
        {
            if (usuarios.ContainsKey(usuario))
            {
                return usuarios[usuario] == contraseña;
            }
            return false;
        }
    }
}
