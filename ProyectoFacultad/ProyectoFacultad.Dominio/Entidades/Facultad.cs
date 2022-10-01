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

            //Pre-cargo algunos casos de ejemplo para 'jugar' con el programa y no tener que realizarlo manualmente cada vez que ejecuto el Programa
            _alumnos.Add(new Alumno("Somoza", DateTime.Now.AddYears(-20), "Miguel", 850000));
            _alumnos.Add(new Alumno("Rodriguez", DateTime.Now.AddYears(-22), "Aldana", 799999));
            _alumnos.Add(new Alumno("Perez", DateTime.Now.AddYears(-24), "Ezequiel", 720000));

            //Pre-cargo algunos casos de ejemplo para 'jugar' con el programa y no tener que realizarlo manualmente cada vez que ejecuto el Programa
            _empleados.Add(new Bedel("Gandolfi", DateTime.Now.AddYears(-44), "Marcela", DateTime.Now.AddYears(-20), 123456, "Cholo"));
            _empleados.Add(new Docente("Baez", DateTime.Now.AddYears(-30), "Lisandro", DateTime.Now.AddYears(-5), 654321));
            _empleados.Add(new Directivo("Gorriti", DateTime.Now.AddYears(-57), "Marcela", DateTime.Now.AddYears(-25), 777777));
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
        public void AgregarEmpleado(string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo, string apodo)
        {
            //Valido que la fecha de nacimiento no sea mayor a la fecha de ingreso a la facultad sino tiro una excepción custom
            if (fechaNac > fechaIngreso)
            {
                throw new FechaNacMayorFechaIngresoException(fechaNac, fechaIngreso);
            }
            else
            {
                Empleado b = new Bedel(apellido, fechaNac, nombre, fechaIngreso, legajo, apodo);

                AgregarEmpleado(b);
            }
        }

        public void AgregarEmpleado(int tipoEmpleado, string apellido, DateTime fechaNac, string nombre, DateTime fechaIngreso, int legajo)
        {
            //Valido si el empleado a dar de alta es un Docente
            if (tipoEmpleado == 2)
            {
                //Valido que la fecha de nacimiento no sea mayor a la fecha de ingreso a la facultad sino tiro una excepción custom
                if (fechaNac > fechaIngreso)
                {
                    throw new FechaNacMayorFechaIngresoException(fechaNac, fechaIngreso);
                }
                else
                {
                    Empleado doc = new Docente(apellido, fechaNac, nombre, fechaIngreso, legajo);

                    AgregarEmpleado(doc);
                }
            }

            //Valido si el empleado a dar de alta es un Directivo
            else
            {
                //Valido que la fecha de nacimiento no sea mayor a la fecha de ingreso a la facultad sino tiro una excepción custom
                if (fechaNac > fechaIngreso)
                {
                    throw new FechaNacMayorFechaIngresoException(fechaNac, fechaIngreso);
                }
                else
                {
                    Empleado dir = new Directivo(apellido, fechaNac, nombre, fechaIngreso, legajo);

                    AgregarEmpleado(dir);
                }
            }
        }

        public void EliminarAlumno(int codigoAlumno)
        {
            //Valido que la lista de alumnos no esté vacía sino tiro una excepción custom
            if (_alumnos.Count == 0)
            {
                throw new ListaVaciaException("Alumnos");
            }
            //Valido que el código de alumno ingresado corresponda a uno existente en el sistema sino tiro una excepción custom
            else if (_alumnos.Find(A => A.Codigo == codigoAlumno) == null)
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
            //Valido que la lista de empleados no esté vacía sino tiro una excepción custom
            if (_empleados.Count == 0)
            {
                throw new ListaVaciaException("Empleados");
            }
            //Valido que el legajo de empleado ingresado corresponda a uno existente en el sistema sino tiro una excepción custom
            else if (_empleados.Find(E => E.Legajo == legajoEmpleado) == null)
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
            //Guardo en una instancia de la clase 'Empleado' el objeto original previo a las modificaciones que realizo el usuario
            Empleado original = _empleados.FirstOrDefault(e => e.Legajo == empleadoModificado.Legajo);

            //Elimino el empleado original previo a las modificaciones
            _empleados.Remove(original);

            //Agrego el empleado modificado
            _empleados.Add(empleadoModificado);
        }

        public List<Alumno> TraerAlumnos()
        {
            //Declaración de lista
            List<Alumno> _alumnosFacultad = new List<Alumno>();

            //Por cada instancia de 'Alumno' en la lista de _alumnos las agrego a la lista _alumnosFacultad
            foreach (Alumno a in _alumnos)
            {
                _alumnosFacultad.Add(a);
            }

            //Valido que la lista de alumnos no esté vacía sino tiro una excepción custom
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

            //Valido que la lista de empleados no esté vacía sino tiro una excepción custom
            if (_empleados.Count == 0)
            {
                throw new ListaVaciaException("Empleados");
            }
            else
            {
                foreach (Empleado e in _empleados)
                {
                    if (e.Legajo == legajoEmpleado)
                    {
                        empleadoResultado = e;
                    }
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

            //Valido que la lista de alumnos no esté vacía sino tiro una excepción custom
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
