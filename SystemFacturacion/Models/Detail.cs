using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Librerias que se usaron
using System.Data.Entity;

namespace SystemFacturacion.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public int BillID { get; set; }
        public int ProductID { get; set; }
        public decimal MaxNum { get; set; }

        //propiedades virutales 
        public virtual ICollection<Bill> Bills { get; set; }
    }
}