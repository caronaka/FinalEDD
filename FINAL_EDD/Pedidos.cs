using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_EDD
{
    class Pedidos
    {

        //Atributos id y nombre
        
        public int Id { get; set; }
        public string Nombre { get; set; }


        public Pedidos(int id, string nombre) //Constructor
        {
            Id = id;
            Nombre = nombre;
        }

    }
}
