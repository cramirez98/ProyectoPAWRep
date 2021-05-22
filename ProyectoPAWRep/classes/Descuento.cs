using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class Descuento
    {
        private int porcentaje;
        private DateTime fechaInicio;
        private DateTime fechaFinalizacion;
        private string nombre;

        public Descuento(int porcentaje, DateTime fechaInicio, DateTime fechaFinalizacion, string nombre)
        {
            this.porcentaje = porcentaje;
            this.fechaInicio = fechaInicio;
            this.fechaFinalizacion = fechaFinalizacion;
            this.nombre = nombre;
        }

        public int Porcentaje { get => porcentaje; set => porcentaje = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFinalizacion { get => fechaFinalizacion; set => fechaFinalizacion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}