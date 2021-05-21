using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_de_Registro_de_Estudiantes.Areas.AreaAdmin.Controllers
{
    public class ListaMateriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}