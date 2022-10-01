using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.InterfazGrafica
{
    public static class ValidacionesInputHelper
    {
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
