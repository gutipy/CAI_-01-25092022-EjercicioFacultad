using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Entidades
{
    public sealed class Bedel : Empleado
    {
        //Atributos
        protected string _apodo;

        //Constructores
        public Bedel(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo, string apodo) : base(apellido, fechaNac, nombre, fechaIngreso, legajo)
        {
            _apodo = apodo;
        }

        //Propiedades
        public string Apodo { get => _apodo; }

        //Funciones-Métodos
        public override string GetNombreCompleto()
        {
            //Declaración de variables
            string nombreCompleto;

            nombreCompleto = "Bedel: " + Apodo;

            return nombreCompleto;
        }
    }
}
