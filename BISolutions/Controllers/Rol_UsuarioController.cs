using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BISolutions.ApplicationServices;
using BISolutions.DataContext;
using BISolutions.Models;

namespace BISolutions.Controllers
{/*
    [Route("api/[controller]")]
    [ApiController]
    public class Rol_UsuarioController : Controller
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly Rol_UsuarioAppService _rolUsuarioAppService;
        public Rol_UsuarioController(BISolutionsDataContext _context, Rol_UsuarioAppService rolUsuarioAppService)
        {
            _baseDatos = _context;
            _rolUsuarioAppService = rolUsuarioAppService;

            if (_baseDatos.Roles_Usuarios.Count() == 0)
            {
                _baseDatos.Roles_Usuarios.Add(new Rol_Usuario { rol_id = 1, usuario_id = 1});
                _baseDatos.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol_Usuario>>> GetRolesUsuarios()
        {
            return await _baseDatos.Roles_Usuarios.Include(q => q.Rol).Include(q => q.Usuario).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol_Usuario>> GetRolUsuario(int id)
        {
            var respuestaAppService = await _rolUsuarioAppService.GetRolUsuarioApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Roles_Usuarios.Include(q => q.Rol).Include(q => q.Usuario).FirstOrDefaultAsync(q => q.rol_usuario_id == id);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Rol_Usuario>> PostRolUsuario(Rol_Usuario rolUsuario)
        {
            var respuestaAppService = await _rolUsuarioAppService.PostRolUsuarioApplicationService(rolUsuario);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetRolUsuario), new { id = rolUsuario.rol_usuario_id }, rolUsuario);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolUsuario(int id, Rol_Usuario rolUsuario)
        {
            var respuestaAppService = await _rolUsuarioAppService.PutRolUsuarioApplicationService(id, rolUsuario);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            var respuestaAppService = await _rolUsuarioAppService.DeleteRolUsuarioApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }
    }*/
}
