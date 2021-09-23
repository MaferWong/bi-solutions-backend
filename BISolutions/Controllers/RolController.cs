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
    public class RolController : Controller
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly RolAppService _rolAppService;
        public RolController(BISolutionsDataContext _context, RolAppService rolAppService)
        {
            _baseDatos = _context;
            _rolAppService = rolAppService;
            /*
            if (_baseDatos.Roles.Count() == 0)
            {
                _baseDatos.Roles.Add(new Rol { rol_descripcion = "Administrador de Sistema"});
                _baseDatos.SaveChanges();
            }*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            return await _baseDatos.Roles.Include(q => q.Reportes_Roles).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var respuestaAppService = await _rolAppService.GetRolApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Roles.Include(q => q.Reportes_Roles).FirstOrDefaultAsync(q => q.rol_id == id);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            var respuestaAppService = await _rolAppService.PostRolApplicationService(rol);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetRol), new { id = rol.rol_id }, rol);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            var respuestaAppService = await _rolAppService.PutRolApplicationService(id, rol);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var respuestaAppService = await _rolAppService.DeleteRolApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }
    }
}
