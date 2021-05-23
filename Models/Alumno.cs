using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

				[Required(ErrorMessage = "Requiere ingresar su matricula.")]
				[StringLength(8)]
        public string Matricula { get; set; }

				[Required(ErrorMessage = "Requiere ingresar una contraseña.")]
        public string Password { get; set; }

				[Required(ErrorMessage = "Requiere ingresar su nombre.")]
        public string Nombre { get; set; }

				[Required(ErrorMessage = "Requiere ingresar su apellido paterno.")]
        public string Apaterno { get; set; }

        public string Amaterno { get; set; }

				[Required(ErrorMessage = "Requiere ingresar su telefono.")]
				[StringLength(10)]
        public string Telefono { get; set; }

				[Required(ErrorMessage = "Requiere ingresar su grupo.")]
				[StringLength(1)]
        public string Grupo { get; set; }

				[Required(ErrorMessage = "Requiere ingresar su semestre.")]
        public int Semestre { get; set; }

				[Required(ErrorMessage = "Requiere ingresar su carrera.")]
        public string Carrera { get; set; }

        public byte[] Foto { get; set; }

        public virtual ICollection<Localizacion> Localizacions { get; set; }
        public virtual ICollection<MisDocumento> MisDocumentos { get; set; }
    }
}
