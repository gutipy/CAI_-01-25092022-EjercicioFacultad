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

            Empleado E1 = new Bedel("Gandolfi", DateTime.Now.AddYears(-44), "Marcela", DateTime.Now.AddYears(-20), 123456, "Cholo");

            Empleado E2 = new Docente("Baez", DateTime.Now.AddYears(-30), "Lisandro", DateTime.Now.AddYears(-5), 654321);

            Empleado E3 = new Directivo("Gorriti", DateTime.Now.AddYears(-57), "Marcela", DateTime.Now.AddYears(-25), 777777);

            Salario S1 = new Salario(100000, "ABC123");

            Salario S2 = new Salario(100000, "ABC123");

            Salario S3 = new Salario(100000, "ABC123");

            Facultad facultad = new Facultad(5, "UBA Económicas");

            facultad.AgregarAlumno(A1);
            facultad.AgregarAlumno(A2);
            facultad.AgregarAlumno(A3);

            facultad.AgregarEmpleado(E1);
            facultad.AgregarEmpleado(E2);
            facultad.AgregarEmpleado(E3);

            E1.AgregarSalario(S1);
            E2.AgregarSalario(S2);
            E3.AgregarSalario(S3);

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
                            //Listar a los alumnos de la facultad
                            ListarA(facultad);
                            break;
                        case "2":
                            //Listar a los empleados de la facultad
                            ListarE(facultad);
                            break;
                        case "3":
                            //Agrego un alumno al sistema
                            AgregarA(facultad);
                            break;
                        case "4":
                            //Elimino un alumno del sistema
                            EliminarA(facultad);
                            break;
                        case "5":
                            //Agrego un empleado al sistema
                            AgregarE(facultad);
                            break;
                        case "6":
                            //Modifico un empleado del sistema
                            ModificarE(facultad);
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
            //Declaración de variables
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
            string resultado = "";


            OpcionesEmpleado();

            FuncionValidacionOpcionEmpleado(ref _opcionEmpleado);

            if (_opcionEmpleado == "1")
            {
                //Declaración de variables
                List<Empleado> _listadoEmpleados = new List<Empleado>();
                

                _listadoEmpleados = facultad.TraerEmpleados();

                foreach (Empleado e in _listadoEmpleados)
                {
                    resultado += e.ToString();
                }

                Console.WriteLine(resultado);

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

                Console.WriteLine("El empleado con legajo" + _legajoValidado + " es:");

                resultado += e.ToString();

                Console.WriteLine(resultado);

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
                    _flag = FuncionValidacionCadena(ref _nombre, "Nombre");

                } while (_flag == false);

                _empleadosPorNombre = facultad.TraerEmpleadosPorNombre(_nombre);

                foreach (Empleado e in _empleadosPorNombre)
                {
                    resultado += e.ToString();
                }

                Console.WriteLine(resultado);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public static void AgregarA(Facultad facultad)
        {
            //Declaración de variables
            string _apellido;
            string _fechaNac;
            DateTime _fechaNacValidada = DateTime.Now;
            string _nombre;
            string _codigo;
            int _codigoValidado = 0;
            bool _flag;

            //Pido al usuario que ingrese los datos del alumno a agregar al sistema
            do
            {
                Console.WriteLine("Ingrese el apellido del alumno");
                _apellido = Console.ReadLine();
                _flag = FuncionValidacionCadena(ref _apellido, "Apellido");
            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese la fecha de nacimiento del alumno");
                _fechaNac = Console.ReadLine();
                _flag = FuncionValidacionFecha(_fechaNac, ref _fechaNacValidada, "Fecha de nacimiento");
            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el nombre del alumno");
                _nombre = Console.ReadLine();
                _flag = FuncionValidacionCadena(ref _nombre, "Nombre");
            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el código del alumno");
                _codigo = Console.ReadLine();
                _flag = FuncionValidacionCodigo(_codigo, ref _codigoValidado, "Código de alumno");
            } while (_flag == false);

            facultad.AgregarAlumno(_apellido, _fechaNacValidada, _nombre, _codigoValidado);

            Console.WriteLine("El alumno " + _apellido + " " + _nombre + " fue agregado exitosamente.");

            Console.WriteLine("Presione Enter para elegir otra opción");
            Console.ReadKey();
            Console.Clear();
        }

        public static void EliminarA(Facultad facultad)
        {
            //Declaración de variables
            string _codigo;
            int _codigoValidado = 0;
            bool _flag;

            do
            {
                Console.WriteLine("Ingrese el código del alumno que desea eliminar");
                _codigo = Console.ReadLine();
                _flag = FuncionValidacionCodigo(_codigo, ref _codigoValidado, "Código de alumno");

            } while (_flag == false);

            facultad.EliminarAlumno(_codigoValidado);

            Console.WriteLine("El alumno con código " + _codigoValidado + " fue eliminado exitosamente.");

            Console.WriteLine("Presione Enter para elegir otra opción");
            Console.ReadKey();
            Console.Clear();
        }

        public static void AgregarE(Facultad facultad)
        {
            //Declaración de variables
            string _tipoEmpleadoOpcion;
            int _tipoEmpleadoOpcionValidado = 0;
            string _apellido;
            string _fechaNac;
            DateTime _fechaNacValidada = DateTime.Now;
            string _nombre;
            string _fechaIngreso;
            DateTime _fechaIngresoValidada = DateTime.Now;
            string _legajo;
            int _legajoValidado = 0;
            string _apodo;
            bool _flag;

            //Pido al usuario que ingrese que tipo de Empleado quiere agregar al sistema
            do
            {
                Console.WriteLine(
                    "¿Qué tipo de empleado desea agregar al sistema? Ingrese alguna de las siguientes opciones: " + Environment.NewLine +
                    "1 - Bedel" + Environment.NewLine +
                    "2 - Docente" + Environment.NewLine +
                    "3 - Directivo" + Environment.NewLine
                    )
                    ;

                _tipoEmpleadoOpcion = Console.ReadLine();
                _flag = FuncionValidacionTipoEmpleado(_tipoEmpleadoOpcion, ref _tipoEmpleadoOpcionValidado, "Tipo de empleado");

            } while (_flag == false);

            if (_tipoEmpleadoOpcionValidado == 1)
            {
                //Pido al usuario que ingrese los datos del Bedel a agregar al sistema
                do
                {
                    Console.WriteLine("Ingrese el apellido del Bedel");
                    _apellido = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apellido, "Apellido");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del Bedel");
                    _fechaNac = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaNac, ref _fechaNacValidada, "Fecha de nacimiento");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el nombre del Bedel");
                    _nombre = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _nombre, "Nombre");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de ingreso del Bedel");
                    _fechaIngreso = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaIngreso, ref _fechaIngresoValidada, "Fecha de ingreso");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el legajo del Bedel");
                    _legajo = Console.ReadLine();
                    _flag = FuncionValidacionLegajo(_legajo, ref _legajoValidado);

                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el apodo del Bedel");
                    _apodo = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apodo, "Apodo");
                } while (_flag == false);

                facultad.AgregarEmpleado(_apellido, _fechaNacValidada, _nombre, _fechaIngresoValidada, _legajoValidado, _apodo);

                Console.WriteLine("El Bedel " + _apellido + " " + _nombre + " fue agregado exitosamente.");

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }

            else if (_tipoEmpleadoOpcionValidado == 2)
            {
                //Pido al usuario que ingrese los datos del Docente a agregar al sistema
                do
                {
                    Console.WriteLine("Ingrese el apellido del Docente");
                    _apellido = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apellido, "Apellido");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del Docente");
                    _fechaNac = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaNac, ref _fechaNacValidada, "Fecha de nacimiento");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el nombre del Docente");
                    _nombre = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _nombre, "Nombre");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de ingreso del Docente");
                    _fechaIngreso = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaIngreso, ref _fechaIngresoValidada, "Fecha de ingreso");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el legajo del Docente");
                    _legajo = Console.ReadLine();
                    _flag = FuncionValidacionLegajo(_legajo, ref _legajoValidado);

                } while (_flag == false);

                facultad.AgregarEmpleado(_tipoEmpleadoOpcionValidado, _apellido, _fechaIngresoValidada, _nombre, _fechaIngresoValidada, _legajoValidado);

                Console.WriteLine("El Docente " + _apellido + " " + _nombre + " fue agregado exitosamente.");

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                //Pido al usuario que ingrese los datos del Directivo a agregar al sistema
                do
                {
                    Console.WriteLine("Ingrese el apellido del Directivo");
                    _apellido = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apellido, "Apellido");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del Directivo");
                    _fechaNac = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaNac, ref _fechaNacValidada, "Fecha de nacimiento");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el nombre del Directivo");
                    _nombre = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _nombre, "Nombre");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de ingreso del Directivo");
                    _fechaIngreso = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaIngreso, ref _fechaIngresoValidada, "Fecha de ingreso");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el legajo del Directivo");
                    _legajo = Console.ReadLine();
                    _flag = FuncionValidacionLegajo(_legajo, ref _legajoValidado);

                } while (_flag == false);

                facultad.AgregarEmpleado(_tipoEmpleadoOpcionValidado, _apellido, _fechaIngresoValidada, _nombre, _fechaIngresoValidada, _legajoValidado);

                Console.WriteLine("El Directivo " + _apellido + " " + _nombre + " fue agregado exitosamente.");

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();

            }
        }

        public static void ModificarE(Facultad facultad)
        {
            //Declaración de variables
            string _legajo;
            int _legajoValidado = 0;
            Empleado empleadoModif = null;
            string _apellido;
            string _fechaNac;
            DateTime _fechaNacValidada = DateTime.Now;
            string _nombre;
            string _fechaIngreso;
            DateTime _fechaIngresoValidada = DateTime.Now;
            string _apodo;
            bool _flag;

            do
            {
                Console.WriteLine("Ingrese el legajo del empleado que desea modificar");
                _legajo = Console.ReadLine();
                _flag = FuncionValidacionLegajo(_legajo, ref _legajoValidado);

            } while (_flag == false);

            empleadoModif = facultad.TraerEmpleadoPorLegajo(_legajoValidado);

            if (empleadoModif is Bedel)
            {
                Bedel bedel = (Bedel)empleadoModif;

                do
                {
                    Console.WriteLine("Ingrese el apellido del Empleado");
                    _apellido = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apellido, "Apellido");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del Empleado");
                    _fechaNac = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaNac, ref _fechaNacValidada, "Fecha de nacimiento");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el nombre del Empleado");
                    _nombre = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _nombre, "Nombre");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de ingreso del Empleado");
                    _fechaIngreso = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaIngreso, ref _fechaIngresoValidada, "Fecha de ingreso");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el apodo del Empleado");
                    _apodo = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apodo, "Apodo");
                } while (_flag == false);

                empleadoModif = new Bedel(
                    _apellido,
                    _fechaNacValidada,
                    _nombre,
                    _fechaIngresoValidada,
                    _legajoValidado,
                    _apodo
                    )
                    ;

                facultad.ModificarEmpleado(empleadoModif);
            }

            else if (empleadoModif is Docente)
            {
                Docente docente = (Docente)empleadoModif;

                do
                {
                    Console.WriteLine("Ingrese el apellido del Empleado");
                    _apellido = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apellido, "Apellido");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del Empleado");
                    _fechaNac = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaNac, ref _fechaNacValidada, "Fecha de nacimiento");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el nombre del Empleado");
                    _nombre = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _nombre, "Nombre");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de ingreso del Empleado");
                    _fechaIngreso = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaIngreso, ref _fechaIngresoValidada, "Fecha de ingreso");
                } while (_flag == false);

                empleadoModif = new Docente(
                    _apellido,
                    _fechaNacValidada,
                    _nombre,
                    _fechaIngresoValidada,
                    _legajoValidado
                    )
                    ;

                facultad.ModificarEmpleado(empleadoModif);
            }

            else
            {
                Directivo directivo = (Directivo)empleadoModif;

                do
                {
                    Console.WriteLine("Ingrese el apellido del Empleado");
                    _apellido = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _apellido, "Apellido");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de nacimiento del Empleado");
                    _fechaNac = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaNac, ref _fechaNacValidada, "Fecha de nacimiento");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese el nombre del Empleado");
                    _nombre = Console.ReadLine();
                    _flag = FuncionValidacionCadena(ref _nombre, "Nombre");
                } while (_flag == false);

                do
                {
                    Console.WriteLine("Ingrese la fecha de ingreso del Empleado");
                    _fechaIngreso = Console.ReadLine();
                    _flag = FuncionValidacionFecha(_fechaIngreso, ref _fechaIngresoValidada, "Fecha de ingreso");
                } while (_flag == false);

                empleadoModif = new Directivo(
                    _apellido,
                    _fechaNacValidada,
                    _nombre,
                    _fechaIngresoValidada,
                    _legajoValidado
                    )
                    ;

                facultad.ModificarEmpleado(empleadoModif);
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

        public static bool FuncionValidacionCadena(ref string cadena, string campo)
        {
            //Declaración de variables
            bool flag = false;

            if (string.IsNullOrEmpty(cadena))
            {
                Console.WriteLine("ERROR! El campo " + campo + " no puede ser vacío, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionFecha(string fecha, ref DateTime fechaValidada, string campo)
        {
            bool flag = false;

            if (!DateTime.TryParse(fecha, out fechaValidada))
            {
                Console.WriteLine("El campo " + campo + " debe tener un formato válido del tipo dd/mm/aaaa, intente nuevamente.");
            }
            else if (fechaValidada > DateTime.Now)
            {
                Console.WriteLine("La fecha ingresada no puede ser superior al día de hoy, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionCodigo(string codigo, ref int codigoValidado, string campo)
        {
            bool flag = false;

            if (!int.TryParse(codigo, out codigoValidado))
            {
                Console.WriteLine("El campo " + campo + " debe tener un formato válido del tipo numérico, intente nuevamente.");
            }
            else if (codigoValidado <= 0)
            {
                Console.WriteLine("El " + campo + " no puede ser igual o menor a cero, intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }

        public static bool FuncionValidacionTipoEmpleado(string tipoEmpleado, ref int tipoEmpleadoValidado, string campo)
        {
            bool flag = false;

            if (!int.TryParse(tipoEmpleado, out tipoEmpleadoValidado))
            {
                Console.WriteLine("El campo " + campo + " debe tener un formato válido del tipo numérico, intente nuevamente.");
            }
            else if (tipoEmpleadoValidado <= 0 || tipoEmpleadoValidado > 3)
            {
                Console.WriteLine("El " + campo + " debe ser un valor entre 1, 2 y 3. Intente nuevamente.");
            }
            else
            {
                flag = true;
            }

            return flag;
        }
    }
}
