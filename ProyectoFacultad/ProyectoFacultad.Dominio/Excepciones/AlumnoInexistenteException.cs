using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Excepciones
{
    public class AlumnoInexistenteException : Exception
    {
        public AlumnoInexistenteException(int codigo) : base("ERROR! El alumno con código " + codigo + " no existe, por favor intente nuevamente.") { }
    }
}
