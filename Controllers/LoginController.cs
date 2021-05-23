﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Registro_de_Estudiantes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Sistema_de_Registro_de_Estudiantes.Controllers
{
    public class LoginController : Controller
    {
        private readonly RegistroEstudiantesContext _context;

				public LoginController(RegistroEstudiantesContext context)
				{
						_context = context;
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
        public async Task<IActionResult> Register([Bind("Matricula,Nombre,Apaterno,Amaterno,Telefono,Grupo,Semestre,Carrera,Password")] Alumno alumno)
        {
						if (ModelState.IsValid)
						{
								_context.Add(alumno);
								await _context.SaveChangesAsync();
								return RedirectToAction("Index");
						}

						return View();
        }
    }
}
