using Microsoft.AspNetCore.Mvc;
using Penca.Models;
using Penca.Services;

namespace Penca.Controllers
{
    public class ConfederacionController : Controller
    {
        private readonly ConfederacionService _service;

        public ConfederacionController()
        {
            _service = new ConfederacionService();
        }

        public IActionResult Index()
        {
            var items = _service.GetConfederaciones();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Confederacion conf)
        {
            if (ModelState.IsValid)
            {
                _service.AddConfederacion(conf);
                return RedirectToAction("Index");
            }
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
            return View(conf);
        }

        [HttpPost]
        public IActionResult Update(Confederacion conf)
        {
            if (!ModelState.IsValid) return View(conf);
            _service.UpdateConfederacion(conf);
            return RedirectToAction("Index");
        }
    }
}
