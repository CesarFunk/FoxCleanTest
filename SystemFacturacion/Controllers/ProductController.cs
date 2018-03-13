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
    public class ProductController : Controller
    {
        private SysDbContext db = new SysDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var data = db.Producto.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Add()
        {
            Product _product = new Product();
            _product.categoria = db.Categoria.ToList();
            
            return View(_product);
        }
        [HttpPost]
        public ActionResult Add(Product pProduct)
        {
            db.Producto.Add(pProduct);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Product Producto = db.Producto.FirstOrDefault(a => a.ProductID == Id);
            Producto.categoria = db.Categoria.ToList();
            return View(Producto);
        }
        [HttpPost]
        public ActionResult Edit(Product pProduct)
        {
            db.Entry(pProduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Product Producto = db.Producto.FirstOrDefault(a => a.ProductID == Id);
            Producto.categoria = db.Categoria.ToList();
            return View(Producto);
        }

        [HttpPost]
        public ActionResult Delete(Product pProduct)
        {
            Product product = db.Producto.FirstOrDefault(a => a.ProductID == pProduct.ProductID);
            db.Producto.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


    }
}