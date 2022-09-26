using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Excepciones
{
    public class NombreInexistenteException : Exception
    {
        public NombreInexistenteException(string nombre) : base("ERROR! No existen empleados con el nombre " + nombre + ", por favor intente nuevamente.") { }
    }
}
