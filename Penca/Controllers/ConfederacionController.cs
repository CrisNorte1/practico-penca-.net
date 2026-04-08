using Microsoft.AspNetCore.Mvc;
using Penca.Models;
using Penca.Services;

namespace Penca.Controllers
{
    public class ConfederacionController : Controller
    {
        private readonly ConfederacionService _service;
        private readonly DeporteService _deporteService;

        public ConfederacionController(ConfederacionService service, DeporteService deporteService)
        {
            _service = service;
            _deporteService = deporteService;
        }

        public IActionResult Index()
        {
            var items = _service.GetConfederaciones();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Deportes = _deporteService.GetDeportes();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Confederacion conf)
        {
            if (ModelState.IsValid)
            {
                _service.AddConfederacion(conf);
                return RedirectToAction("Index");
            }
            ViewBag.Deportes = _deporteService.GetDeportes();
            return View(conf);
        }

        public IActionResult Delete(long id)
        {
            var conf = _service.GetConfederaciones().FirstOrDefault(c => c.Id == id);
            if (conf != null) _service.RemoveConfederacion(conf);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var conf = _service.GetConfederaciones().FirstOrDefault(c => c.Id == id);
            if (conf == null) return NotFound();
            ViewBag.Deportes = _deporteService.GetDeportes();
            return View(conf);
        }

        [HttpPost]
        public IActionResult Update(Confederacion conf)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Deportes = _deporteService.GetDeportes();
                return View(conf);
            }
            _service.UpdateConfederacion(conf);
            return RedirectToAction("Index");
        }
    }
}
