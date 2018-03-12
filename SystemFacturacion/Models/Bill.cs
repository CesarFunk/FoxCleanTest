using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Librerias que se usaron
using System.Data.Entity;

namespace SystemFacturacion.Models
{
    public class Bill
    {
        public int BillID { get; set; }
        public int CostumerID { get; set; }
        public DateTime Date { get; set; }
        public int PayCode { get; set; }

        //propiedades virtuales
        public virtual Costumer cliente { get; set; }
    }
}