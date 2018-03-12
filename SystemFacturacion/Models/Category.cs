using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemFacturacion.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        //propiedades virtuales
        public virtual ICollection<Product> Producto { get; set; }
    }
}