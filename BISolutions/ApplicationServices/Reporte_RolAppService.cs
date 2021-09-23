using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BISolutions.DataContext;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutions.ApplicationServices
{
    public class Reporte_RolAppService
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly Reporte_RolDomainService _reporteRolDomainService;
        public Reporte_RolAppService(BISolutionsDataContext _context, Reporte_RolDomainService reporteRolDomainService)
        {
            _baseDatos = _context;
            _reporteRolDomainService = reporteRolDomainService;
        }
        public async Task<string> GetReporteRolApplicationService(int id)
        {
            var reporteRol = await _baseDatos.Reportes_Roles.Include(q => q.Rol).Include(q => q.Reporte).FirstOrDefaultAsync(q => q.reporte_rol_id == id);

            var respuestaDomainService = _reporteRolDomainService.GetReporteRolDomainService(id, reporteRol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostReporteRolApplicationService(Reporte_Rol reporteRol)
        {
            var respuestaDomainService = _reporteRolDomainService.PostReporteRolDomainService(reporteRol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Reportes_Roles.Add(reporteRol);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutReporteRolApplicationService(int id, Reporte_Rol reporteRol)
        {
            Rol rol = await _baseDatos.Roles.FirstOrDefaultAsync(q => q.rol_id == reporteRol.rol_id);
            Reporte reporte = await _baseDatos.Reportes.FirstOrDefaultAsync(q => q.reporte_id == reporteRol.reporte_id);

            var respuestaDomainService = _reporteRolDomainService.PutReporteRolDomainService(id, reporteRol, rol, reporte);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(reporteRol).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteReporteRolApplicationService(int id)
        {
            var reporteRol = await _baseDatos.Reportes_Roles.FindAsync(id);

            var respuestaDomainService = _reporteRolDomainService.DeleteReporteRolDomainService(id, reporteRol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Reportes_Roles.Remove(reporteRol);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
