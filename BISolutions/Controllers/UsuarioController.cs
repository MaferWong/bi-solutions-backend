using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BISolutions.ApplicationServices;
using BISolutions.DataContext;
using BISolutions.Models;

namespace BISolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly UsuarioAppService _usuarioAppService;
        public UsuarioController(BISolutionsDataContext _context, UsuarioAppService usuarioAppService)
        {
            _baseDatos = _context;
            _usuarioAppService = usuarioAppService;
            /*
            if (_baseDatos.Usuarios.Count() == 0)
            {
                _baseDatos.Usuarios.Add(new Usuario { usuario_nombre = "Usuario de Prueba", usuario_correo = "it.intern@altiabusinesspark.com", usuario_contrasena = "ItIntern1234", usuario_rol_id = 1 });
                _baseDatos.SaveChanges();
            }*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _baseDatos.Usuarios.Include(q => q.Rol).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var respuestaAppService = await _usuarioAppService.GetUsuarioApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Usuarios.Include(q => q.Rol).FirstOrDefaultAsync(q => q.usuario_id == id);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            var respuestaAppService = await _usuarioAppService.PostUsuarioApplicationService(usuario);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetUsuario), new { id = usuario.usuario_id }, usuario);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            var respuestaAppService = await _usuarioAppService.PutUsuarioApplicationService(id, usuario);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var respuestaAppService = await _usuarioAppService.DeleteUsuarioApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }
    }
}
