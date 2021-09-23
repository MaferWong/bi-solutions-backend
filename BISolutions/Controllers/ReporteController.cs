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
    public class ReporteController : Controller
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly ReporteAppService _reporteAppService;
        public ReporteController(BISolutionsDataContext _context, ReporteAppService reporteAppService)
        {
            _baseDatos = _context;
            _reporteAppService = reporteAppService;
            /*
            if (_baseDatos.Reportes.Count() == 0)
            {
                _baseDatos.Reportes.Add(new Reporte { reporte_descripcion = "Reporte de Prueba", reporte_URL = "https://app.powerbi.com/reportEmbed?reportId=28e60dbb-f6b7-44f7-9345-627f452f4291&autoAuth=true&ctid=df178cd5-c418-42f2-becc-9a19dd282438&config=eyJjbHVzdGVyVXJsIjoiaHR0cHM6Ly93YWJpLXNvdXRoLWNlbnRyYWwtdXMtcmVkaXJlY3QuYW5hbHlzaXMud2luZG93cy5uZXQvIn0%3D", reporte_activo = "true" });
                _baseDatos.SaveChanges();
            }*/
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reporte>>> GetReportes()
        {
            return await _baseDatos.Reportes.Include(q => q.Reportes_Roles).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reporte>> GetReporte(int id)
        {
            var respuestaAppService = await _reporteAppService.GetReporteApplicationService(id);
            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return await _baseDatos.Reportes.Include(q => q.Reportes_Roles).FirstOrDefaultAsync(q => q.reporte_id == id);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPost]
        public async Task<ActionResult<Reporte>> PostReporte(Reporte reporte)
        {
            var respuestaAppService = await _reporteAppService.PostReporteApplicationService(reporte);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return CreatedAtAction(nameof(GetReporte), new { id = reporte.reporte_id }, reporte);
            }
            return BadRequest(respuestaAppService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporte(int id, Reporte reporte)
        {
            var respuestaAppService = await _reporteAppService.PutReporteApplicationService(id, reporte);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporte(int id)
        {
            var respuestaAppService = await _reporteAppService.DeleteReporteApplicationService(id);

            bool noHayErroresEnValidaciones = respuestaAppService == null;

            if (noHayErroresEnValidaciones)
            {
                return NoContent();
            }
            return BadRequest(respuestaAppService);
        }
    }
}
