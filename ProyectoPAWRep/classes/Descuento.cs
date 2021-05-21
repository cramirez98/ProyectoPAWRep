using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class Descuento
    {
        private float porcentaje;
        private DateTime FechaInicio;
        private DateTime FechaFinalizacion;
        private string nombre;

        public Descuento(float porcentaje, DateTime fechaInicio, DateTime fechaFinalizacion, string nombre)
        {
            this.porcentaje = porcentaje;
            FechaInicio = fechaInicio;
            FechaFinalizacion = fechaFinalizacion;
            this.nombre = nombre;
        }

        public float Porcentaje { get => porcentaje; set => porcentaje = value; }
        public DateTime FechaInicio1 { get => FechaInicio; set => FechaInicio = value; }
        public DateTime FechaFinalizacion1 { get => FechaFinalizacion; set => FechaFinalizacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}