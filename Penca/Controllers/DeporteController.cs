using Microsoft.AspNetCore.Mvc;
using Penca.Models;
using Penca.Services;

namespace Penca.Controllers
{
    public class DeporteController : Controller
    {
        private readonly DeporteService _service;

        public DeporteController()
        {
            _service = new DeporteService();
        }

        public IActionResult Index()
        {
            var items = _service.GetDeportes();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Deporte d)
        {
            if (ModelState.IsValid)
            {
                _service.AddDeporte(d);
                return RedirectToAction("Index");
            }
            return View(d);
        }

        public IActionResult Delete(long id)
        {
            var d = _service.GetDeportes().FirstOrDefault(x => x.Id == id);
            if (d != null) _service.RemoveDeporte(d);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var d = _service.GetDeportes().FirstOrDefault(x => x.Id == id);
            if (d == null) return NotFound();
            return View(d);
        }

        [HttpPost]
        public IActionResult Update(Deporte d)
        {
            if (!ModelState.IsValid) return View(d);
            _service.UpdateDeporte(d);
            return RedirectToAction("Index");
        }
    }
}
