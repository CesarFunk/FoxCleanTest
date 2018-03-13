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
    public class CostumerController : Controller
    {
        private SysDbContext db = new SysDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var data = db.Cliente.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Costumer pCliente)
        {
            db.Cliente.Add(pCliente);
            db.SaveChanges();

            return RedirectToAction("Index", "Costumer");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Costumer Cliente = db.Cliente.FirstOrDefault(a => a.CostumerID == Id);
            return View(Cliente);
        }
        [HttpPost]
        public ActionResult Edit(Costumer pCliente)
        {
            db.Entry(pCliente).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Costumer");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Costumer Cliente = db.Cliente.FirstOrDefault(a => a.CostumerID == Id);
            return View(Cliente);
        }

        [HttpPost]
        public ActionResult Delete(Costumer pCliente)
        {
            Costumer cliente = db.Cliente.FirstOrDefault(a => a.CostumerID == pCliente.CostumerID);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index", "Costumer");
        }
    }
}