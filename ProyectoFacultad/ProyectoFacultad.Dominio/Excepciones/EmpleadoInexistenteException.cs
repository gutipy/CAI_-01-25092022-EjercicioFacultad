using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Excepciones
{
    public class EmpleadoInexistenteException : Exception
    {
        public EmpleadoInexistenteException(int legajo) : base("ERROR! El empleado con legajo " + legajo + " no existe, por favor intente nuevamente.") { }
    }
}
