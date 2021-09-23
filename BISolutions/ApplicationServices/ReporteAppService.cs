using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BISolutions.DataContext;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutions.ApplicationServices
{
    public class ReporteAppService
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly ReporteDomainService _reporteDomainService;
        public ReporteAppService(BISolutionsDataContext _context, ReporteDomainService reporteDomainService)
        {
            _baseDatos = _context;
            _reporteDomainService = reporteDomainService;
        }
        public async Task<string> GetReporteApplicationService(int id)
        {
            var reporte = await _baseDatos.Reportes.Include(q => q.Reportes_Roles).FirstOrDefaultAsync(q => q.reporte_id == id);

            var respuestaDomainService = _reporteDomainService.GetReporteDomainService(id, reporte);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostReporteApplicationService(Reporte reporte)
        {
            var respuestaDomainService = _reporteDomainService.PostReporteDomainService(reporte);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Reportes.Add(reporte);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutReporteApplicationService(int id, Reporte reporte)
        {
            var respuestaDomainService = _reporteDomainService.PutReporteDomainService(id, reporte);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(reporte).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteReporteApplicationService(int id)
        {
            var reporte = await _baseDatos.Reportes.FindAsync(id);

            var respuestaDomainService = _reporteDomainService.DeleteReporteDomainService(id, reporte);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Reportes.Remove(reporte);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
