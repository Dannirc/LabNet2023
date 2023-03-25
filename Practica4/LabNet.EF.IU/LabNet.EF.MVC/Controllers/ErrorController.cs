using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNet.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View("ErrorView");
        }
    }
}