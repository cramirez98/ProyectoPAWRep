using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class PaymentObject
    {
        private string nombres;
        private string apellidos;
        private string correo;
        private string telefono;
        private string cedula;
        private string ciudad;
        private string direccion;
        private int numerohabitacion;
        private double valorpago;
        private string fechainicio;
        private string fechafinalizacion;
        private int numeropersonas;
        private string correou;
        private string metododepago;

        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Numerohabitacion { get => numerohabitacion; set => numerohabitacion = value; }
        public double Valorpago { get => valorpago; set => valorpago = value; }
        public string Fechainicio { get => fechainicio; set => fechainicio = value; }
        public string Fechafinalizacion { get => fechafinalizacion; set => fechafinalizacion = value; }
        public int Numeropersonas { get => numeropersonas; set => numeropersonas = value; }
        public string Correou { get => correou; set => correou = value; }
        public string Metododepago { get => metododepago; set => metododepago = value; }
    }
}