using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {

        /*
         mostrar todos
        insertar uno
        mostrar por título
        editar
        eliminar-----------------------------------------
        traer uno----------------------------------------
         */

        //Context
        private readonly DBEmpleadosContext context;

        //Inyección de dependencias
        public EmpleadoController(DBEmpleadosContext context)
        {
            this.context = context;
        }

        //Todos
        public IActionResult Index()
        {
            return View(context.Empleados.ToList());
        }

        //Traer uno
        private Empleado TraerUno(int id)
        {
            return context.Empleados.Find(id);
        }

        //CREATE GET
        [HttpGet]
        public ActionResult Insertar()
        {
            Empleado empleado = new Empleado();

            return View("Insertar");
        }

        //CREATE POST
        [HttpPost]
        public ActionResult Insertar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Insertar", empleado);
        }

        //POR TITULO GET
        [HttpGet]
        public IActionResult EmpleadosPorTitulo(string titulo)
        {
            var empleadosPorTitulo = (from emp in context.Empleados where emp.Titulo == titulo select emp).ToList();

            return View("Index", empleadosPorTitulo);
        }

        //EDITAR GET
        [HttpGet]
        public ActionResult Editar(int id)
        {
            var empleado = TraerUno(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View("Editar", empleado);
        }

        //EDITAR POST
        [HttpPost]
        [ActionName("Editar")]
        public ActionResult EditConfirmed(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Entry(empleado).State = EntityState.Modified;

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        //ELIMINAR GET
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var empleado = TraerUno(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View("Eliminar", empleado);
        }

        //ELIMINAR POST
        [ActionName("Eliminar")]
        [HttpPost]
        public ActionResult EliminarConfirmed(int id)
        {
            var empleado = TraerUno(id);

            if (empleado == null)
            {
                return NotFound();
            }

            context.Empleados.Remove(empleado);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        //DETALLE GET
        [HttpGet]
        public ActionResult Detalle(int id)
        {
            Empleado empleado = TraerUno(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View("Detalle", empleado);
        }
    }
}
