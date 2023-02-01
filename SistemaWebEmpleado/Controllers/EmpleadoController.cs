using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DBEmpleadosContext context;

        public EmpleadoController(DBEmpleadosContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var empleados = context.Empleados.ToList();

            return View(empleados);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var empleado = TraerUno(id);

            return View(empleado);

        }


        [HttpGet]
        public ActionResult GetByTitulo(string titulo)
        {
            var empleados = (from a in context.Empleados
                                  where a.Titulo == titulo
                                  select a).ToList();

            return View(empleados);

        }


        [HttpGet]
        public ActionResult Create()
        {
            Empleado empleado = new Empleado();

            return View("Create", empleado);
        }


        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empleado = TraerUno(id);
            return View("Edit", empleado);
        }


        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(int id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }
            else
            {
                context.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", empleado);
            }
        }


        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Empleado empleado = TraerUno(id);
            if (empleado == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", empleado);
            }

        }


        private Empleado TraerUno(int id)
        {
            return context.Empleados.Find(id);
        }

    }
}
