using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//modelos
using SystemFacturacion.Models;
using SystemFacturacion.DAL;
using System.Data.Entity;

namespace SystemFacturacion.Controllers
{
    public class DetailController : Controller
    {
        private SysDbContext db = new SysDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var data = db.Detalle.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Detail pBill)
        {
            db.Detalle.Add(pBill);
            db.SaveChanges();

            return RedirectToAction("Index", "Detail");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Detail Factura = db.Detalle.FirstOrDefault(a => a.DetailID == Id);
            return View(Factura);
        }
        [HttpPost]
        public ActionResult Edit(Detail pBill)
        {
            db.Entry(pBill).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Detail");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Detail Factura = db.Detalle.FirstOrDefault(a => a.DetailID == Id);
            return View(Factura);
        }

        [HttpPost]
        public ActionResult Delete(Detail pBill)
        {
            Detail Factura = db.Detalle.FirstOrDefault(a => a.DetailID == pBill.DetailID);
            db.Detalle.Remove(Factura);
            db.SaveChanges();
            return RedirectToAction("Index", "Detail");
        }
    }
}