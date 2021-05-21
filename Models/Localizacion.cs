using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema_de_Registro_de_Estudiantes.Models
{
    public partial class Localizacion
    {
        public int IdLoc { get; set; }
        public string Matricula { get; set; }
        public string Localidad { get; set; }
        public string CiudadOrigen { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string CodigoPostal { get; set; }

        public virtual Alumno MatriculaNavigation { get; set; }
    }
}
