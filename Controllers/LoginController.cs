using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Registro_de_Estudiantes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Sistema_de_Registro_de_Estudiantes.Controllers
{
    public class LoginController : Controller
    {
        private readonly RegistroEstudiantesContext _context;
				private IWebHostEnvironment _environment;

				public LoginController(RegistroEstudiantesContext context, IWebHostEnvironment environment)
				{
						_context = context;
						_environment = environment;
				}

        public IActionResult Index()
        {
						string matricula = HttpContext.Session.GetString("Matricula");
						if (matricula == null)
						{
								return View();
						} 
						else 
						{
								return RedirectToAction("Index", "AreaAdmin");
						}
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Matricula,Password")] Alumno alumno)
        {
            var autentificado = await _context.Alumnos.
							FirstOrDefaultAsync(m => m.Matricula == alumno.Matricula);
						
						if (autentificado != null && autentificado.Password == alumno.Password) {
								HttpContext.Session.SetString("Matricula", autentificado.Matricula);
								return RedirectToAction("Index", "AreaAdmin");
						}

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
						return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Matricula,Nombre,Apaterno,Amaterno,Telefono,Grupo,Semestre,Carrera,Password,ConfirmPassword")] Alumno alumno, List<IFormFile> postedFiles)
        {
						if (ModelState.IsValid)
						{
								try
								{
										_context.Add(alumno);
										await _context.SaveChangesAsync();
										HttpContext.Session.SetString("Matricula", alumno.Matricula);
										string path = Path.Combine(_environment.WebRootPath, "fotos");
										foreach (IFormFile postedFile in postedFiles)
										{
												using (FileStream stream = new FileStream(Path.Combine(path, alumno.Matricula + ".png"), FileMode.Create))
												{
														postedFile.CopyTo(stream);
												}
										}
										return RedirectToAction("Index");
								}
								catch (Microsoft.EntityFrameworkCore.DbUpdateException)
								{
										var matriculaRepetida = await _context.Alumnos.
											FirstOrDefaultAsync(m => m.Matricula == alumno.Matricula);

										if (matriculaRepetida != null) {
												ModelState.AddModelError("Matricula", "Matricula ya registrada");
										}

										var telefonoRepetido = await _context.Alumnos.
											FirstOrDefaultAsync(m => m.Telefono == alumno.Telefono);

										if (telefonoRepetido != null) {
												ModelState.AddModelError("Telefono", "Telefono ya registrado");
										}

										return View(alumno);
								}
						}
						return View(alumno);
        }
    }
}
