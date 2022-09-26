using ProyectoFacultad.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.InterfazGrafica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaración de variables
            bool _consolaActiva = true;
            string _opcionMenu = "";

            Alumno A1 = new Alumno("Somoza", DateTime.Now.AddYears(-20), "Miguel", 850000);

            Alumno A2 = new Alumno("Rodriguez", DateTime.Now.AddYears(-22), "Aldana", 799999);

            Alumno A3 = new Alumno("Perez", DateTime.Now.AddYears(-24), "Ezequiel", 720000);

            Empleado E1 = new Bedel("Gandolfi", DateTime.Now.AddYears(-44), "Rodolfo", DateTime.Now.AddYears(-20), 123456, "Cholo");

            Empleado E2 = new Docente("Baez", DateTime.Now.AddYears(-30), "Lisandro", DateTime.Now.AddYears(-5), 654321);

            Empleado E3 = new Directivo("Gorriti", DateTime.Now.AddYears(-57), "Marcela", DateTime.Now.AddYears(-25), 777777);



            Facultad facultad = new Facultad(5, "UBA Económicas");

            facultad.AgregarAlumno(A1);
            facultad.AgregarAlumno(A2);
            facultad.AgregarAlumno(A3);

            facultad.AgregarEmpleado(E1);
            facultad.AgregarEmpleado(E2);
            facultad.AgregarEmpleado(E3);

            try
            {
                while (_consolaActiva)
                {
                    //Despliego en pantalla las opciones para que el usuario decida
                    OpcionesMenu();

                    //Se valida que la opcion ingresada no sea vacío y/o distinta de las opciones permitidas
                    FuncionValidacionOpcionMenu(ref _opcionMenu);

                    //Estructura condicional para controlar el flujo del programa
                    switch (_opcionMenu)
                    {
                        case "1":
                            //Listar a los alumnos
                            ListarA(facultad);
                            break;
                        case "2":
                            //Agrego un repuesto al listado
                            ListarE(facultad);
                            break;
                        case "3":
                            //Elimino un repuesto del listado
                            //Eliminar(gestorRepuestos);
                            break;
                        case "4":
                            //Modifico el precio de un repuesto
                            //Modificar(gestorRepuestos);
                            break;
                        case "5":
                            //Agrego el stock de un repuesto
                            //AgregarS(gestorRepuestos);
                            break;
                        case "6":
                            //Modifico el precio de un repuesto
                            //QuitarS(gestorRepuestos);
                            break;
                        case "7":
                            //Salgo del programa
                            //Salir();
                            break;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        public static void OpcionesMenu()
        {
            Console.WriteLine(
                "¡Bienvenido al gestor de la Facultad de Ciencias Económicas de la UBA! Seleccione una opción:" + Environment.NewLine +
                "1 - Listar a los alumnos" + Environment.NewLine +
                "2 - Listar a los empleados" + Environment.NewLine +
                "3 - Agregar un alumno" + Environment.NewLine +
                "4 - Eliminar un alumno" + Environment.NewLine +
                "5 - Agregar un empleado" + Environment.NewLine +
                "6 - Modificar un empleado" + Environment.NewLine +
                "7 - Eliminar un empleado" + Environment.NewLine +
                "8 - Salir"
                )
                ;
        }

        public static void OpcionesEmpleado()
        {
            Console.WriteLine(
                "¿Como desea listar a los empleados? Ingrese alguna de las siguientes opciones: " + Environment.NewLine +
                "1 - Listar todos los empleados" + Environment.NewLine +
                "2 - Listar empleados por legajo" + Environment.NewLine +
                "3 - Listar empleados por nombre" + Environment.NewLine
                )
                ;
        }

        public static void ListarA(Facultad facultad)
        {
            //Declaración de lista
            List<Alumno> _listadoAlumnos = new List<Alumno>();
            string resultado = "";

            _listadoAlumnos = facultad.TraerAlumnos();

            foreach (Alumno a in _listadoAlumnos)
            {
                resultado += a.ToString();
            }

            Console.WriteLine(resultado);

            Console.WriteLine("Presione Enter para elegir otra opción");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ListarE(Facultad facultad)
        {
            //Declaración de variables
            string _opcionEmpleado = "";
            string _legajo;
            int _legajoValidado = 0;
            string _nombre = "";
            bool _flag;


            OpcionesEmpleado();

            FuncionValidacionOpcionEmpleado(ref _opcionEmpleado);

            if (_opcionEmpleado == "1")
            {
                //Declaración de lista
                List<Empleado> _listadoEmpleados = new List<Empleado>();

                _listadoEmpleados = facultad.TraerEmpleados();

                foreach (Empleado e in _listadoEmpleados)
                {
                    e.ToString();
                }

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
            else if (_opcionEmpleado == "2")
            {
                do
                {
                    Console.WriteLine("Ingrese el legajo del empleado que desea traer");
                    _legajo = Console.ReadLine();
                    _flag = FuncionValidacionLegajo(_legajo, ref _legajoValidado);

                }while (_flag == false);

                Empleado e = facultad.TraerEmpleadoPorLegajo(_legajoValidado);

                Console.WriteLine("El empleado con " + _legajoValidado + " es:");
                
                e.ToString();

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                //Declaración de lista
                List<Empleado> _empleadosPorNombre = new List<Empleado>();

                do
                {
                    Console.WriteLine("Ingrese el nombre de los empleados que desea listar");
                    _nombre = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _nombre);

                } while (_flag == false);

                _empleadosPorNombre = facultad.TraerEmpleadosPorNombre(_nombre);

                foreach (Empleado e in _empleadosPorNombre)
                {
                    e.ToString();
                }

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }

        }

        //Funciones que validan los inputs requeridos al usuario
        public static string FuncionValidacionOpcionMenu(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5" || opcion == "6" || opcion == "7" || opcion == "8")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcion;
        }

        public static string FuncionValidacionOpcionEmpleado(ref string opcion)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                opcion = Console.ReadLine();

                if (string.IsNullOrEmpty(opcion))
                {
                    Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
                }
                else if (opcion == "1" || opcion == "2" || opcion == "3")
                {
                    flag = true;
                }
                else
                {
                    Console.WriteLine("ERROR! La opción " + opcion + " no es una opción válida, intente nuevamente.");
                }
            } while (flag == false);

            return opcion;
        }

        public static bool FuncionValidacionLegajo(string legajo, ref int legajoValidado)
        {
            //Declaración de variables
            bool flag = false;

            do
            {
                if (!int.TryParse(legajo, out legajoValidado))
                {
                    Console.WriteLine("El legajo ingresado debe ser de tipo numérico, intente nuevamente.");
                }
                else if (legajoValidado <= 0)
                {
                    Console.WriteLine("El legajo ingresado debe ser mayor a cero, intente nuevamente");
                }
                else if (legajoValidado.ToString().Length >= 10)
                {
                    Console.WriteLine("El legajo ingresado no puede tener diez o más dígitos, intente nuevamente");
                }
                else
                {
                    flag = true;
                }
            } while (flag == false);

            return flag;
        }

        public static bool FuncionValidacionCadena(ref string cadena)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(cadena))
            {
                Console.WriteLine("ERROR! La opción ingresada no puede ser vacío, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }
    }
}
