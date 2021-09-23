using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BISolutions.DataContext;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutions.ApplicationServices
{
    public class RolAppService
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly RolDomainService _rolDomainService;
        public RolAppService(BISolutionsDataContext _context, RolDomainService rolDomainService)
        {
            _baseDatos = _context;
            _rolDomainService = rolDomainService;
        }
        public async Task<string> GetRolApplicationService(int id)
        {
            var rol = await _baseDatos.Roles.Include(q => q.Reportes_Roles).FirstOrDefaultAsync(q => q.rol_id == id);

            var respuestaDomainService = _rolDomainService.GetRolDomainService(id, rol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostRolApplicationService(Rol rol)
        {
            var respuestaDomainService = _rolDomainService.PostRolDomainService(rol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Roles.Add(rol);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutRolApplicationService(int id, Rol rol)
        {
            var respuestaDomainService = _rolDomainService.PutRolDomainService(id, rol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(rol).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteRolApplicationService(int id)
        {
            var rol = await _baseDatos.Roles.FindAsync(id);

            var respuestaDomainService = _rolDomainService.DeleteRolDomainService(id, rol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Roles.Remove(rol);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
