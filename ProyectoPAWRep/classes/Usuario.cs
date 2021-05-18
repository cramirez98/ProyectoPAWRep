using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class Usuario
    {
        private string nombres;
        private string apellidos;
        private string correo;
        private string contraseña;
        private string celular;
        private string cedula;
        private string direccion;
        private string ciudad;
        private int edad;
        private string tipo;

        public Usuario(string nombres, string apellidos, string correo, string contraseña, string celular, string cedula, string ciudad, int edad, string tipo, string direccion)
        {
            this.Nombres = nombres;
            this.apellidos = apellidos;
            this.correo = correo;
            this.contraseña = contraseña;
            this.celular = celular;
            this.cedula = cedula;
            this.ciudad = ciudad;
            this.edad = edad;
            this.tipo = tipo;
            this.direccion = direccion;
        }

        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Direccion { get => direccion; set => direccion = value; }
    }
}