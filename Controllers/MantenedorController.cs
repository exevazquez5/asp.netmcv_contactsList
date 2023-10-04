using Microsoft.AspNetCore.Mvc;
using asp_practica1._1.Datos;
using asp_practica1._1.Models;

namespace asp_practica1._1.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos _contactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            // VISTA PARA LISTAR LOS CONTACTOS
            var oLista = _contactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            // METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]

        public IActionResult Guardar(ContactoModel oContacto)
        {
            // METODO RECIBIR UN OBJETO Y GUARDARLO EN LA BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _contactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdContacto) // metodo para ver vista
        {
            // METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto) // metodo para obtener el objeto
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _contactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto) // metodo para ver vista
        {
            // METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _contactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto) // metodo para obtener el objeto
        {

            var respuesta = _contactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
