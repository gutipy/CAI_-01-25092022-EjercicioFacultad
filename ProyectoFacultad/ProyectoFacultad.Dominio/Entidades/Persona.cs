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

        }

        public string GetNombreCompleto()
        {

        }
    }
}
