using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Librerias que se usaron
using System.Data.Entity;
using SystemFacturacion.Models;
using SystemFacturacion.DAL;

namespace SystemFacturacion.Controllers
{
    public class HomeController : Controller
    {

        //Inicio
        private SysDbContext _db = new SysDbContext();

        public ActionResult Index()
        {
            var clientes = _db.Cliente.ToList().Count();
            var facturas = _db.Factura.ToList().Count();
            var productos = _db.Producto.ToList().Count();

            ViewBag.Clientes = clientes;
            ViewBag.Facturas = facturas;
            ViewBag.Productos = productos;

            return View();
        }

      
    }
}