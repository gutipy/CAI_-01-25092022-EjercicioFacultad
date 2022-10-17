using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFacultad.Dominio.Entidades;
using ProyectoFacultad.Dominio.Excepciones;

namespace ProyectoFacultad.Dominio.Entidades
{
    public abstract class Empleado : Persona
    {
        //Atributos
        private DateTime _fechaIngreso;
        private int _legajo;
        private List<Salario> _salarios;

        //Constructores
        public Empleado(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre)
        {
            _fechaIngreso = fechaIngreso;
            _legajo = legajo;
            _salarios = new List<Salario>();

            //Pre-cargo algunos casos de ejemplo para 'jugar' con el programa y no tener que realizarlo manualmente cada vez que ejecuto el Programa
            _salarios.Add(new Salario(100000, "ABC123"));
            _salarios.Add(new Salario(100000, "ABC123"));
            _salarios.Add(new Salario(100000, "ABC123"));
        }

        //Propiedades
        public int Antiguedad { get => (DateTime.Now - _fechaIngreso).Days / 365; }
        public DateTime FechaIngreso { get => _fechaIngreso; }
        public DateTime FechaNacimiento { get => FechaNac; }
        public int Legajo { get => _legajo; }
        public List<Salario> Salarios { get => _salarios; }
        public Salario UltimoSalario { get => _salarios.Last(); }

        //Funciones-Métodos

        public void AgregarSalario(Salario salario)
        {
            //Se valida que el salario neto no sea negativo sino se tira una excepción custom
            if ((salario.Bruto - salario.Descuentos) <= 0)
            {
                throw new SalarioNegativoException(salario);
            }
            else
            {
                _salarios.Add(salario);
            }
        }

        //public override bool Equals(Object obj)
        //{
        //    if(obj == null)
        //    {
        //        return false;
        //    }
        //    else if (obj is Empleado)
        //    {
        //        Empleado emp = (Empleado)obj;

        //        foreach(Facultad e in _empleados)
        //        {
        //            if (e.Legajo == emp.Legajo)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Función que devuelve las credenciales del empleado
        public override string GetCredencial()
        {
            //Declaración de variables
            string _nombreCompleto;

            _nombreCompleto = GetNombreCompleto();

            return string.Format(
                "Legajo: {0}" + Environment.NewLine +
                "Nombre completo: {1}" + Environment.NewLine +
                "Salario: {2}" + Environment.NewLine,
                Legajo,
                _nombreCompleto,
                UltimoSalario
                )
                ;
        }

        //Función sobreescrita que llama a 'GetCredencial()' para almacenar las credenciales del empleado en una variable y retornarlas al usuario
        public override string ToString()
        {
            //Declaración de variables
            string resultado;

            resultado = GetCredencial();

            return resultado;
        }

        public abstract override string GetNombreCompleto();
    }
}
