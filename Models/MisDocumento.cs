using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema_de_Registro_de_Estudiantes.Models
{
    public partial class MisDocumento
    {
        public string Matricula { get; set; }
        public int IdDocs { get; set; }
        public byte[] Rfc { get; set; }
        public byte[] ActaNacimiento { get; set; }
        public byte[] Curp { get; set; }

        public virtual Alumno MatriculaNavigation { get; set; }
    }
}
