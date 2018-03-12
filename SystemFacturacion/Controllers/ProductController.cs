using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//modelos
using SystemFacturacion.Models;
using SystemFacturacion.DAL;


namespace SystemFacturacion.Controllers
{
    public class ProductController : Controller
    {
        private SysDbContext db = new SysDbContext();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult loadData()
        {
           
                var data = db.Producto.OrderBy(a => a.Name).ToList();
           
                return Json(data, JsonRequestBehavior.AllowGet);
            
        }

        [HttpGet]
        public ActionResult Save(int Id)
        {
           
                var dab = db.Producto.Where(a => a.ProductID == Id).FirstOrDefault();
                return View(dab);
           
        }

    }
}