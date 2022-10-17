using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Entidades
{
    public sealed class Directivo : Empleado
    {
        //Atributos

        //Constructores
        public Directivo(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre, fechaIngreso, legajo)
        {

        }

        //Propiedades

        //Funciones-Métodos
        public override string GetNombreCompleto()
        {
            //Declaración de variables
            string nombreCompleto;

            nombreCompleto = "Sr. Director: " + Apellido;

            return nombreCompleto;
        }
    }
}
