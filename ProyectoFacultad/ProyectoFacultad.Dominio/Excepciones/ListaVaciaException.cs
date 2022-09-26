using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Excepciones
{
    public class ListaVaciaException : Exception
    {
        public ListaVaciaException(string lista) : base("ERROR! La lista de " + lista + " se encuentra vacía, por favor intente nuevamente.") { }
    }
}
