using Microsoft.AspNetCore.Mvc;
using APPBUSCO.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APPBUSCO.Controllers
{
    public class SolicitudesController:Controller
    {
        private readonly ProductoContext _context;
        public SolicitudesController(ProductoContext context){
            _context = context;

        }

        private IActionResult Productos()
        {
            var productos = _context.Productos.Include(x => x.Categoria).OrderBy(r => r.Nombre).ToList();
            return View(productos);
        }

        public IActionResult NuevoProducto(){
            ViewBag.categorias= _context.Categorias.ToList().Select(r => new SelectListItem(r.Nombre, r.Id.ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult NuevoProducto(Producto r){
            if(ModelState.IsValid)
            {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("NuevoProductoConfirmacion");
            }
            return View(r);
        }
        public IActionResult NuevoProductoConfirmacion(){
            return View();
        }

    }
}