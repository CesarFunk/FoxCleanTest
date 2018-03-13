using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Librerias que se usaron
using System.Data.Entity;

namespace SystemFacturacion.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
    
        public int CategoryID { get; set; }
        public DateTime Date { get; set; }
   


        //propiedades virtuales
        public virtual ICollection<Detail> Detalle { get; set; }
        public virtual ICollection<Category> categoria { get; set; }
        public virtual Category _Categoria { get; set; }
    }
}