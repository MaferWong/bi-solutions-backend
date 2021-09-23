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
    public class Reporte_RolController : Controller
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly Reporte_RolAppService _reporteRolAppService;
        public Reporte_RolController(BISolutionsDataContext _context, Reporte_RolAppService reporteRolAppService)
        {
            _baseDatos = _context;
            _reporteRolAppService = reporteRolAppService;
            /*
            if (_baseDatos.Reportes_Roles.Count() == 0)
            {
                _baseDatos.Reportes_Roles.Add(new Reporte_Rol { rol_id = 1, reporte_id = 1 });
                _baseDatos.SaveChanges();
            }*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reporte_Rol>>> GetReportesRoles()
        {
            return await _baseDatos.Reportes_Roles.Include(q => q.Reporte).Include(q => q.Rol).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reporte_Rol>> GetReporteRol(int id)
        {
            var respuestaAppService = await _reporteRolAppService.GetReporteRolApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Reportes_Roles.Include(q => q.Reporte).Include(q => q.Rol).FirstOrDefaultAsync(q => q.reporte_rol_id == id);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Reporte_Rol>> PostReporteRol(Reporte_Rol reporteRol)
        {
            var respuestaAppService = await _reporteRolAppService.PostReporteRolApplicationService(reporteRol);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetReporteRol), new { id = reporteRol.reporte_rol_id }, reporteRol);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporteRol(int id, Reporte_Rol reporteRol)
        {
            var respuestaAppService = await _reporteRolAppService.PutReporteRolApplicationService(id, reporteRol);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporteRol(int id)
        {
            var respuestaAppService = await _reporteRolAppService.DeleteReporteRolApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }
    }
}
