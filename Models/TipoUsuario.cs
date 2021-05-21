using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema_de_Registro_de_Estudiantes.Models
{
    public partial class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
    }
}
