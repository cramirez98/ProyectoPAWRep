﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class Reserva
    {
        private string habitacion_id;
        private string cliente_id;
        private DateTime fechainicio;
        private DateTime fechafinalizacion;
        private double valorpago;
        private DateTime fechapago;

        public Reserva(string habitacion_id, string cliente_id, DateTime fechainicio, DateTime fechafinalizacion, double valorpago, DateTime fechapago)
        {
            this.habitacion_id = habitacion_id;
            this.cliente_id = cliente_id;
            this.fechainicio = fechainicio;
            this.fechafinalizacion = fechafinalizacion;
            this.valorpago = valorpago;
            this.fechapago = fechapago;
        }

        public string Habitacion_id { get => habitacion_id; set => habitacion_id = value; }
        public string Cliente_id { get => cliente_id; set => cliente_id = value; }
        public DateTime Fechainicio { get => fechainicio; set => fechainicio = value; }
        public DateTime Fechafinalizacion { get => fechafinalizacion; set => fechafinalizacion = value; }
        public double Valorpago { get => valorpago; set => valorpago = value; }
        public DateTime Fechapago { get => fechapago; set => fechapago = value; }
    }
}