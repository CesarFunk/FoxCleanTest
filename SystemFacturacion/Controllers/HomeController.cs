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
            _db.Cliente.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}