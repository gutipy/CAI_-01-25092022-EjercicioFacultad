using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFacultad.Dominio.Entidades;

namespace ProyectoFacultad.Dominio.Entidades
{
    public abstract class Empleado : Persona
    {
        //Atributos
        protected DateTime _fechaIngreso;
        protected int _legajo;
        protected List<Salario> _salarios;

        //Constructores
        public Empleado(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo) : base(apellido, fechaNac, nombre)
        {
            _fechaIngreso = fechaIngreso;
            _legajo = legajo;
            _salarios = new List<Salario>();
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
            if ((salario.Bruto - salario.Descuentos) <= 0)
            {
                throw new SalarioNegativoException(salario);
            }
            else
            {
                _salarios.Add(salario);
            }
        }

        public override bool Equals(Object obj)
        {
            if(obj == Legajo)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
