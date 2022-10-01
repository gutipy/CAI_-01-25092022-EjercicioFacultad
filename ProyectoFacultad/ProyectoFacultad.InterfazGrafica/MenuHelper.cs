using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.InterfazGrafica
{
    public static class MenuHelper
    {
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
    }
}
