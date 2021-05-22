using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema_de_Registro_de_Estudiantes.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Localizacions = new HashSet<Localizacion>();
            MisDocumentos = new HashSet<MisDocumento>();
        }

        public string Matricula { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apaterno { get; set; }
        public string Amaterno { get; set; }
        public string Telefono { get; set; }
        public string Grupo { get; set; }
        public int Semestre { get; set; }
        public string Carrera { get; set; }
        public byte[] Foto { get; set; }

        public virtual ICollection<Localizacion> Localizacions { get; set; }
        public virtual ICollection<MisDocumento> MisDocumentos { get; set; }
    }
}
