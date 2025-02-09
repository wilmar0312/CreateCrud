using Microsoft.AspNetCore.Mvc;

using CRUD.WebApp.Data;
using CRUD.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDBContext _appDbContext;
        public UsuariosController(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Usuarios> lista = await _appDbContext.Usuarios.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Usuarios usuarios)
        {
            await _appDbContext.Usuarios.AddAsync(usuarios);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
