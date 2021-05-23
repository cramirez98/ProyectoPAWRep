using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class PaginationObject
    {
        private int pagina_actual;
        private int numero_paginas;
        private int elementos_por_pagina;
        private int pagina_a_cargar;
        private string order_by;
        private string direction;

        private bool advanceSearch;
        private bool changed_order;
        private DateTime fechaInicio;
        private DateTime fechaFinalizacion;
        private double minPrecio;
        private double maxPrecio;
        private string tamaño;
        private int bañosPDiscapacitadas;
        private int mascotas;
        private int numeroCamas;
        private int numeroEstrellas;

        public int Pagina_actual { get => pagina_actual; set => pagina_actual = value; }
        public int Numero_paginas { get => numero_paginas; set => numero_paginas = value; }
        public int Elementos_por_pagina { get => elementos_por_pagina; set => elementos_por_pagina = value; }
        public int Pagina_a_cargar { get => pagina_a_cargar; set => pagina_a_cargar = value; }
        public bool AdvanceSearch { get => advanceSearch; set => advanceSearch = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFinalizacion { get => fechaFinalizacion; set => fechaFinalizacion = value; }
        public double MinPrecio { get => minPrecio; set => minPrecio = value; }
        public double MaxPrecio { get => maxPrecio; set => maxPrecio = value; }
        public string Tamaño { get => tamaño; set => tamaño = value; }
        public int BañosPDiscapacitadas { get => bañosPDiscapacitadas; set => bañosPDiscapacitadas = value; }
        public int Mascotas { get => mascotas; set => mascotas = value; }
        public int NumeroCamas { get => numeroCamas; set => numeroCamas = value; }
        public int NumeroEstrellas { get => numeroEstrellas; set => numeroEstrellas = value; }
        public string Order_by { get => order_by; set => order_by = value; }
        public string Direction { get => direction; set => direction = value; }
        public bool Changed_order { get => changed_order; set => changed_order = value; }
    }
}