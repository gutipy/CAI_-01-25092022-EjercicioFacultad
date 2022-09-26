using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProyectoFacultad.Dominio.Excepciones;

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
            _alumnos.Add(alumno);
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
            _empleados.Add(empleado);
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
                _alumnos.RemoveAll(A => A.Codigo == codigoAlumno);
            }
        }

        public void EliminarEmpleado(int legajoEmpleado)
        {
            if (_empleados.Find(E => E.Legajo == legajoEmpleado) == null)
            {
                throw new EmpleadoInexistenteException(legajoEmpleado);
            }
            else
            {
                _empleados.RemoveAll(E => E.Legajo == legajoEmpleado);
            }
        }

        public void ModificarEmpleado(Empleado empleadoModificado)
        {
            Empleado original = _empleados.FirstOrDefault(e => e.Legajo == empleadoModificado.Legajo);

            _empleados.Remove(original);

            _empleados.Add(empleadoModificado);
        }

        public List<Alumno> TraerAlumnos()
        {
            //Declaración de lista
            List<Alumno> _alumnosFacultad = new List<Alumno>();

            foreach (Alumno a in _alumnos)
            {
                _alumnosFacultad.Add(a);
            }

            if (_alumnosFacultad.Count == 0)
            {
                throw new ListaVaciaException("Alumnos");
            }

            return _alumnosFacultad;
        }

        public Empleado TraerEmpleadoPorLegajo(int legajoEmpleado)
        {
            //Declaración de variables
            Empleado empleadoResultado = null;

            foreach (Empleado e in _empleados)
            {
                if (e.Legajo == legajoEmpleado)
                {
                    empleadoResultado = e;
                }
            }

            return empleadoResultado;
        }

        public List<Empleado> TraerEmpleados()
        {
            //Declaración de lista
            List<Empleado> _empleadosFacultad = new List<Empleado>();

            foreach (Empleado e in _empleados)
            {
                _empleadosFacultad.Add(e);
            }

            if (_empleadosFacultad.Count == 0)
            {
                throw new ListaVaciaException("Empleados");
            }

            return _empleadosFacultad;
        }

        public List<Empleado> TraerEmpleadosPorNombre(string nombreEmpleado)
        {
            //Declaración de lista
            List<Empleado> _empleadosFacultad = new List<Empleado>();

            foreach (Empleado e in _empleados)
            {
                if (e.Nombre == nombreEmpleado)
                {
                    _empleadosFacultad.Add(e);
                }
            }

            if (_empleadosFacultad.Count == 0)
            {
                throw new NombreInexistenteException(nombreEmpleado);
            }
            else
            {
                return _empleadosFacultad;
            }
        }

        public string ValidarEmpleado(int legajoEmpleado)
        {
            //Declaración de variables
            string _resultado = "";

            foreach (Empleado e in _empleados)
            {
                if (e.Legajo == legajoEmpleado)
                {
                    _resultado = "El legajo " + legajoEmpleado + " existe y corresponde a " + e.Nombre + " " + e.Apellido;
                }
            }

            if (string.IsNullOrEmpty(_resultado))
            {
                _resultado = "El legajo " + legajoEmpleado + " no corresponde a ningún empleado de la facultad";
            }

            return _resultado;
        }

        public string ValidarAlumno(int codigoAlumno)
        {
            //Declaración de variables
            string _resultado = "";

            foreach (Alumno a in _alumnos)
            {
                if (a.Codigo == codigoAlumno)
                {
                    _resultado = "El codigo de alumno " + codigoAlumno + " existe y corresponde a " + a.Nombre + " " + a.Apellido;
                }
            }

            if (string.IsNullOrEmpty(_resultado))
            {
                _resultado = "El codigo de alumno " + codigoAlumno + " no corresponde a ningún alumno de la facultad";
            }

            return _resultado;
        }
    }
}
