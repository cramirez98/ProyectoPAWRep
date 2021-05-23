using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class Testimonio
    {
        private string cliente_id;
        private string comentario;
        private int puntaje;
        private string habitacion_id;

        public Testimonio(string cliente_id, string comentario, int puntaje, string habitacion_id)
        {
            this.cliente_id = cliente_id;
            this.comentario = comentario;
            this.puntaje = puntaje;
            this.habitacion_id = habitacion_id;
        }

        public string Cliente_id { get => cliente_id; set => cliente_id = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
        public string Habitacion_id { get => habitacion_id; set => habitacion_id = value; }
    }
}