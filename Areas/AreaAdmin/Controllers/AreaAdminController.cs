using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Registro_de_Estudiantes.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Sistema_de_Registro_de_Estudiantes.Areas.AreaAdmin.Controllers
{
		[Area("AreaAdmin")]
    public class AreaAdminController : Controller
    {
        private readonly RegistroEstudiantesContext _context;
				private IWebHostEnvironment _environment;

				public AreaAdminController(RegistroEstudiantesContext context, IWebHostEnvironment environment)
				{
						_context = context;
						_environment = environment;
				}

        public async Task<IActionResult> Index()
        {
						string matricula = HttpContext.Session.GetString("Matricula");
						if (matricula == null)
						{
								return RedirectToAction("Index", "Home", new {area=""});
						}
            var autentificado = await _context.Alumnos.
							FirstOrDefaultAsync(m => m.Matricula == matricula);
            return View(autentificado);
        }

        public async Task<IActionResult> ListaMaterias()
        {
						string matricula = HttpContext.Session.GetString("Matricula");
						if (matricula == null)
						{
								return RedirectToAction("Index", "Home", new {area=""});
						}
            var autentificado = await _context.Alumnos.
							FirstOrDefaultAsync(m => m.Matricula == matricula);
            return View(autentificado);
        }

				public IActionResult Salir()
				{
						HttpContext.Session.Clear();
						return RedirectToAction("Index", "Home", new {area=""});
				}

				public async Task<IActionResult> Reinscripcion()
				{
						string matricula = HttpContext.Session.GetString("Matricula");
						if (matricula == null)
						{
								return RedirectToAction("Index", "Home", new {area=""});
						}
            var autentificado = await _context.Alumnos.
							FirstOrDefaultAsync(m => m.Matricula == matricula);
            return View(autentificado);
				}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reinscripcion(List<IFormFile> postedFiles)
        {
						string matricula = HttpContext.Session.GetString("Matricula");
						if (matricula == null)
						{
								return RedirectToAction("Index", "Home", new {area=""});
						}
            var autentificado = await _context.Alumnos.
							FirstOrDefaultAsync(m => m.Matricula == matricula);

						string path = Path.Combine(_environment.WebRootPath, "archivos");
						path = Path.Combine(path, autentificado.Matricula);
						System.IO.Directory.CreateDirectory(path);
						foreach (IFormFile postedFile in postedFiles)
						{
								using (FileStream stream = new FileStream(Path.Combine(path, postedFile.FileName), FileMode.Create))
								{
										postedFile.CopyTo(stream);
								}
						}

						return RedirectToAction("Index");
        }
    }
}
