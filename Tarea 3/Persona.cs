using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_3
{
   public class Persona
    {
        public int id { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public string Telefono { get; set; }


        public Persona() { }

        public Persona(int id, string Nombre, int Edad, string Telefono)
        {
            this.id = id;
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Telefono = Telefono; 
        }

    }
}
