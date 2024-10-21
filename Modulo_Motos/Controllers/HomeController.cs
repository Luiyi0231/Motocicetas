using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;


namespace Modulo_Motos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Motos() { 
            return View();
        }

        [HttpGet]
        public JsonResult ListarMotos() { 
            List<Moto> olista = new List<Moto>();
            olista = new CN_Motos().Listar();
            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
    }
}