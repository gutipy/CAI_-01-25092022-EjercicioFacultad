using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Entidades
{
    public class Facultad
    {
        //Atributos
        private List<Alumno> _alumnos;
        private int _cantidadSedes;
        private List<Empleado> _empleados;
        private string _nombre;

        //Constructores
        public Facultad(int cantidadSedes, string nombre)
        {
            _alumnos = new List<Alumno>();
            _cantidadSedes = cantidadSedes;
            _empleados = new List<Empleado>();
            _nombre = nombre;
        }

        //Propiedades
        public int CantidadSedes { get => _cantidadSedes; }
        public string Nombre { get => _nombre; }

        //Funciones-Métodos

        //Método para agregar alumno mediante el pasaje del objeto
        public void AgregarAlumno(Alumno alumno)
        {
            if(_alumnos.Count == 0)
            {
                throw new ListaVaciaException("Alumnos");
            }
            else
            {
                _alumnos.Add(alumno);
            }
        }

        //Método para agregar alumno mediante el pasaje del los inputs
        public void AgregarAlumno(string apellido, DateTime fechaNac, string nombre, int codigo)
        {
            Alumno a = new Alumno(apellido, fechaNac, nombre, codigo);

            AgregarAlumno(a);
        }

        //Método para agregar empleado mediante el pasaje del objeto
        public void AgregarEmpleado(Empleado empleado)
        {
            if (_empleados.Count == 0)
            {
                throw new ListaVaciaException("Empleados");
            }
            else
            {
                _empleados.Add(empleado);
            }
        }

        //Método para agregar empleado mediante el pasaje del los inputs
        public void AgregarEmpleado(int tipoEmpleado, string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo, string apodo)
        {
            //Valido si el empleado a dar de alta es un Bedel
            if (tipoEmpleado == 1)
            {
                Empleado b = new Bedel(apellido, fechaNac, nombre, fechaIngreso, legajo, apodo);

                AgregarEmpleado(b);
            }

            //Valido si el empleado a dar de alta es un Docente
            else if (tipoEmpleado == 2)
            {
                Empleado doc = new Docente(apellido, fechaNac, nombre, fechaIngreso, legajo);

                AgregarEmpleado(doc);
            }

            //Valido si el empleado a dar de alta es un Directivo
            else
            {
                Empleado dir = new Directivo(apellido, fechaNac, nombre, fechaIngreso, legajo);

                AgregarEmpleado(dir);
            }
        }

        public void EliminarAlumno(int codigoAlumno)
        {
            if (_alumnos.Find(A => A.Codigo == codigoAlumno) == null)
            {
                throw new AlumnoInexistenteException(codigoAlumno);
            }
            else
            {
                _alumnos.RemoveAll(C => C.Codigo == codigoAlumno);
            }
        }
    }
}
