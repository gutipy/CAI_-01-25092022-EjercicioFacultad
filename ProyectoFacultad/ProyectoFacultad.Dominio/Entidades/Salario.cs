using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFacultad.Dominio.Entidades
{
    public class Salario
    {
        //Atributos
        private double _bruto;
        private string _codigoTransferencia;
        private double _descuentos;
        private DateTime _fecha;

        //Constructores
        public Salario(double bruto, string codigoTransferencia)
        {
            _bruto = bruto;
            _codigoTransferencia = codigoTransferencia;
            _fecha = DateTime.Now;
        }

        //Propiedades
        public double Bruto { get => _bruto; }
        public string CodigoTransferencia { get => _codigoTransferencia; }
        public double Descuentos { get => _descuentos; }
        public DateTime Fecha { get => _fecha; }
    }
}
