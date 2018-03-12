using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SystemFacturacion.Models
{
    [DataContract(IsReference = true)]
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        //propiedades virtuales
        public virtual ICollection<Product> Producto { get; set; }
    }
}