using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult GetAll()
        {
            return View();
        }

        public JsonResult Get()
        {
            ML.Result result = BL.Empleado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int Id)
        {
            ML.Result result = BL.Empleado.GetById(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEstado()
        {
            ML.Result result = BL.Estado.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int Id)
        {
            ML.Result result = BL.Empleado.Delete(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}