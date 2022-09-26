using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio
{
    public abstract class Persona
    {
        //Atributos
        private string _apellido;
        private DateTime _fechaNac;
        private string _nombre;

        //Constructores
        public Persona(string apellido, DateTime fechaNac, string nombre)
        {
            _apellido = apellido;
            _fechaNac = fechaNac;
            _nombre = nombre;
        }

        //Propiedades
        public string Apellido { get => _apellido; }
        public int Edad { get => (DateTime.Now - _fechaNac).Days / 365; }
        public string Nombre { get => _nombre; }
        public DateTime FechaNac { get => _fechaNac; }

        //Funciones-Métodos
        public string GetCredencial()
        {
            return string.Format(
                "Apellido: {0}" + Environment.NewLine +
                "Nombre: {1}" + Environment.NewLine +
                "Fecha de nacimiento: {2}" + Environment.NewLine,
                "Edad: {3}" + Environment.NewLine,
                Apellido,
                Nombre,
                FechaNac,
                Edad
                )
                ;
        }

        public string GetNombreCompleto()
        {
            //Declaración de variables
            string nombreCompleto;

            nombreCompleto = Nombre + " " + Apellido;

            return nombreCompleto;
        }
    }
}
