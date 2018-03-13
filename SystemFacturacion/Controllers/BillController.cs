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
    public class BillController : Controller
    {
      
        private SysDbContext db = new SysDbContext();
        // GET: Category
        public ActionResult Index()
        {
            Bill fat = new Bill();     
            
            fat._lista = db.Cliente.ToList();

            ICollection<Bill> query = db.Factura.ToList();
        
            query.Add(fat);

            query.Where(x => x.CostumerID == x._Cliente.CostumerID);

            return View(query);
        }
        [HttpGet]
        public ActionResult Add()
        {
            Bill bill = new Bill();
            bill._lista = db.Cliente.ToList();
            return View(bill);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Bill pBill)
        {
            db.Factura.Add(pBill);
            db.SaveChanges();

            return RedirectToAction("Index", "Bill");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
         
            
            Bill Factura = db.Factura.FirstOrDefault(a => a.BillID == Id);
            Factura._lista = db.Cliente.ToList();
            return View(Factura);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bill pBill)
        {
            db.Entry(pBill).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Bill");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Bill Factura = db.Factura.FirstOrDefault(a => a.BillID == Id);
            Factura._Cliente = db.Cliente.Where(x => x.CostumerID == Factura.CostumerID).FirstOrDefault();
            return View(Factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Bill pBill)
        {
            Bill Factura = db.Factura.FirstOrDefault(a => a.BillID == pBill.BillID);
            db.Factura.Remove(Factura);
            db.SaveChanges();
            return RedirectToAction("Index", "Bill");
        }
    }
}