using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFacultad.Dominio.Entidades;

namespace ProyectoFacultad.Dominio.Excepciones
{
    public class SalarioNegativoException : Exception
    {
        public SalarioNegativoException(Salario salario) : base("ERROR! El salario bruto $"
            + salario.Bruto + " menos los descuentos ($" + salario.Descuentos + ") da como resultado un número negativo, esto no es posible. Intente nuevamente.") { }
    }
}
