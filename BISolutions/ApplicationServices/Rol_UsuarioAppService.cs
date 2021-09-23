using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BISolutions.DataContext;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutions.ApplicationServices
{
    public class Rol_UsuarioAppService
    {/*
        private readonly BISolutionsDataContext _baseDatos;
        private readonly Rol_UsuarioDomainService _rolUsuarioDomainService;
        public Rol_UsuarioAppService(BISolutionsDataContext _context, Rol_UsuarioDomainService rolUsuarioDomainService)
        {
            _baseDatos = _context;
            _rolUsuarioDomainService = rolUsuarioDomainService;
        }
        public async Task<string> GetRolUsuarioApplicationService(int id)
        {
            var rolUsuario = await _baseDatos.Roles_Usuarios.Include(q => q.Rol).Include(q => q.Usuario).FirstOrDefaultAsync(q => q.rol_usuario_id == id);

            var respuestaDomainService = _rolUsuarioDomainService.GetRolUsuarioDomainService(id, rolUsuario);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostRolUsuarioApplicationService(Rol_Usuario rolUsuario)
        {
            var respuestaDomainService = _rolUsuarioDomainService.PostRolUsuarioDomainService(rolUsuario);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Roles_Usuarios.Add(rolUsuario);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutRolUsuarioApplicationService(int id, Rol_Usuario rolUsuario)
        {
            Rol rol = await _baseDatos.Roles.FirstOrDefaultAsync(q => q.rol_id == rolUsuario.rol_id);
            Usuario usuario = await _baseDatos.Usuarios.FirstOrDefaultAsync(q => q.usuario_id == rolUsuario.usuario_id);

            var respuestaDomainService = _rolUsuarioDomainService.PutRolUsuarioDomainService(id, rolUsuario, rol, usuario);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Entry(rolUsuario).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteRolUsuarioApplicationService(int id)
        {
            var rolUsuario = await _baseDatos.Roles_Usuarios.FindAsync(id);

            var respuestaDomainService = _rolUsuarioDomainService.DeleteRolUsuarioDomainService(id, rolUsuario);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Roles_Usuarios.Remove(rolUsuario);
            await _baseDatos.SaveChangesAsync();

            return null;
        }*/
    }
}
