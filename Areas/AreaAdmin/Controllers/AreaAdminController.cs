using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Registro_de_Estudiantes.Models;

namespace Sistema_de_Registro_de_Estudiantes.Areas.AreaAdmin.Controllers
{
		[Area("AreaAdmin")]
    public class AreaAdminController : Controller
    {
        private readonly RegistroEstudiantesContext _context;

				public AreaAdminController(RegistroEstudiantesContext context)
				{
						_context = context;
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
    }
}
