using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Entidades
{
    public class Alumno : Persona
    {
        //Atributos
        protected int _codigo;

        //Constructores
        public Alumno(string apellido, DateTime fechaNac, string nombre, int codigo) : base (apellido, fechaNac, nombre)
        {
            _codigo = codigo;
        }

        //Propiedades
        public int Codigo { get => _codigo; }
        public string Credencial { get => ToString(); }

        //Funciones-Metodos
        public string GetCredencial()
        {
            return string.Format(
                "Código: {0}" + Environment.NewLine +
                "Nombre: {1}" + Environment.NewLine +
                "Apellido: {2}" + Environment.NewLine,
                Codigo,
                Nombre,
                Apellido
                )
                ;
        }

        public override string ToString()
        {
            //Declaración de variables
            string resultado;

            resultado = GetCredencial();

            return resultado;
        }
    }
}
