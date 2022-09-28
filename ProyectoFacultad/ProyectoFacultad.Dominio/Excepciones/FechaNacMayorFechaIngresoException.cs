using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Excepciones
{
    public class FechaNacMayorFechaIngresoException : Exception
    {
        public FechaNacMayorFechaIngresoException(DateTime fechaNac, DateTime fechaIngreso) : base(
            "ERROR! La fecha de nacimiento " + fechaNac + " es mayor a la fecha de ingreso " + fechaIngreso + ", por favor ingrese fechas válidas e intente nuevamente.") { }
    }
}
