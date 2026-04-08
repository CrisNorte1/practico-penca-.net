using Microsoft.AspNetCore.Mvc;
using Penca.Data;
using Penca.Models;
using Penca.Services;

namespace Penca.Controllers
{
    public class PaisController : Controller
    {
        private readonly PaisService _paisService;
        private readonly ConfederacionService _confederacionService;

        public PaisController(PaisService paisService, ConfederacionService confederacionService)
        {
            _paisService = paisService;
            _confederacionService = confederacionService;
        }

        public IActionResult Index()
        {
            var paises = _paisService.GetPaises();
            return View(paises);

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Confederaciones = _confederacionService.GetConfederaciones();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pais pais)
        {
            if (ModelState.IsValid)
            {
                _paisService.AddPais(pais);
                return RedirectToAction("Index");
            }
            ViewBag.Confederaciones = _confederacionService.GetConfederaciones();
            return View(pais);
        }

        public IActionResult Delete(long id)
        {
            var pais = _paisService.GetPaises().FirstOrDefault(p => p.Id == id);
            if (pais != null)
            {
                _paisService.RemovePais(pais);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var pais = _paisService.GetPaises().FirstOrDefault(p => p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            ViewBag.Confederaciones = _confederacionService.GetConfederaciones();
            return View(pais);
        }

        [HttpPost]
        public IActionResult Update(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Confederaciones = _confederacionService.GetConfederaciones();
                return View(pais);
            }

            _paisService.UpdatePais(pais);
            return RedirectToAction("Index");
        }
    }
}