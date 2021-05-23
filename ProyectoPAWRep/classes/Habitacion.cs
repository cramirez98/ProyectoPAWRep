using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ProyectoPAWRep.classes
{
    public class Habitacion
    {
        private int numero;
        private string descripcion;
        private XDocument fotos;
        private double precios;
        private string tamaño;
        private double puntaje;
        private int camas;
        private int mascotas;
        private int bañosdiscapacitados;
        private int ocupada;
        private string cliente_id;
        private string descuento_id;

        public Habitacion(int numero, string descripcion, XDocument fotos, double precios, string tamaño, double puntaje, int camas, int mascotas, int bañosdiscapacitados, int ocupada, string cliente_id, string descuento_id)
        {
            this.numero = numero;
            this.descripcion = descripcion;
            this.fotos = fotos;
            this.precios = precios;
            this.tamaño = tamaño;
            this.puntaje = puntaje;
            this.camas = camas;
            this.mascotas = mascotas;
            this.bañosdiscapacitados = bañosdiscapacitados;
            this.ocupada = ocupada;
            this.cliente_id = cliente_id;
            this.descuento_id = descuento_id;
        }

        public int Numero { get => numero; set => numero = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public XDocument Fotos { get => fotos; set => fotos = value; }
        public double Precios { get => precios; set => precios = value; }
        public string Tamaño { get => tamaño; set => tamaño = value; }
        public double Puntaje { get => puntaje; set => puntaje = value; }
        public int Camas { get => camas; set => camas = value; }
        public int Mascotas { get => mascotas; set => mascotas = value; }
        public int Bañosdiscapacitados { get => bañosdiscapacitados; set => bañosdiscapacitados = value; }
        public int Ocupada { get => ocupada; set => ocupada = value; }
        public string Cliente_id { get => cliente_id; set => cliente_id = value; }
        public string Descuento_id { get => descuento_id; set => descuento_id = value; }
    }
}