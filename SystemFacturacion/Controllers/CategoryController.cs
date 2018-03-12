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
    public class CategoryController : Controller
    {
        private SysDbContext db = new SysDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var data = db.Categoria.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category pCategory)
        {
            db.Categoria.Add(pCategory);
            db.SaveChanges();

            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
           Category Categoria = db.Categoria.FirstOrDefault(a => a.CategoryID == Id);
            return View(Categoria);
        }
        [HttpPost]
        public ActionResult Edit(Category pCategory)
        {
            db.Entry(pCategory).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Category Categoria = db.Categoria.FirstOrDefault(a => a.CategoryID == Id);
            return View(Categoria);
        }

        [HttpPost]
        public ActionResult Delete(Category pCategory)
        {
            Category category = db.Categoria.FirstOrDefault(a => a.CategoryID == pCategory.CategoryID);
                db.Categoria.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}