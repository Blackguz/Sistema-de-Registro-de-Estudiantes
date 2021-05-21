using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema_de_Registro_de_Estudiantes.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nomusuario { get; set; }
        public string Passusuario { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
    }
}
