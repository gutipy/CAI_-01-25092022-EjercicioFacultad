using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Entidades
{
    public sealed class Docente : Empleado
    {
        //Atributos

        //Constructores
        public Docente(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre, fechaIngreso, legajo)
        {

        }

        //Propiedades

        //Funciones-Métodos
        public new string GetNombreCompleto()
        {
            //Declaración de variables
            string nombreCompleto;

            nombreCompleto = "Docente: " + Nombre;

            return nombreCompleto;
        }
    }
}
