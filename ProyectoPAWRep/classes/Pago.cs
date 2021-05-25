using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class Pago
    {
        private string nombres;
        private string apellidos;
        private string correo;
        private string telefono;
        private string cedula;
        private string ciudad;
        private string direccion;
        private double valorpago;
        private string metodo;
        private string concepto;

        public Pago(string nombres, string apellidos, string correo, string telefono, string cedula, string ciudad, string direccion, double valorpago, string metodo, string concepto)
        {
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.correo = correo;
            this.telefono = telefono;
            this.cedula = cedula;
            this.ciudad = ciudad;
            this.direccion = direccion;
            this.valorpago = valorpago;
            this.metodo = metodo;
            this.concepto = concepto;
        }

        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public double Valorpago { get => valorpago; set => valorpago = value; }
        public string Metodo { get => metodo; set => metodo = value; }
        public string Concepto { get => concepto; set => concepto = value; }
    }
}