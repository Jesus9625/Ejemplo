using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly SqliteEmpleadosRepository empleados;

        public EmpleadosController(){

            empleados = new SqliteEmpleadosRepository("DataSource=app.db");
        }
        // GET: Empleados
        public ActionResult Index()
        {
            var model = empleados.LeerTodos();
            return View(model);
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
           var model = empleados.LeerPorId(id);
            return View(model);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            var model = new EmpleadoModel();
            return View(model);
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoModel model)
        {
            try
            {
                // TODO: Add insert logic here
                empleados.Crear(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {
            var model = empleados.LeerPorId(id);

            if(model == null){
                return NotFound();
            }
            return View(model);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmpleadoModel model)
        {
            try
            {
                var empleado = empleados.LeerPorId(id);

                if(model == null){
                    return NotFound();
                 }
                // TODO: Add update logic here
                empleados.Actualizar(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            var model = empleados.LeerPorId(id);

                if(model == null){
                    return NotFound();
                 }
            return View(model);
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EmpleadoModel model)
        {
            try
            {
                // TODO: Add delete logic here
                empleados.Borrar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}