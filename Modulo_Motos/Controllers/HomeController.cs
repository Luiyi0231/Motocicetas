using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
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

        [HttpPost]
        public JsonResult GuardarMoto(Moto objeto)
        {
            Object Resultado;
            string Mensaje = string.Empty;

            if (objeto.Id_Moto == 0)
            {
                Resultado = new CN_Motos().Registrar(objeto, out Mensaje);
            }else
            {
                Resultado = new CN_Motos().Editar(objeto, out Mensaje);
            }

            return Json(new { Resultado =   Resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult EliminarMoto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            // Llamada a la capa de negocio para eliminar la moto
            respuesta = new CN_Motos().Eliminar(id, out mensaje);

            return Json(new { Resultado = respuesta, Mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }



    }


}