using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaWebEmpleado.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.Nombre = "Bienvenido al sistema de administración de Empleados.";

            ViewBag.Fecha = DateTime.Now.ToString();

            return View();

        }
    }
}
