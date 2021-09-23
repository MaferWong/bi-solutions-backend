using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BISolutions.DataContext;
using BISolutions.DomainService;
using BISolutions.Models;
using BISolutions.Funcion_Hash;

namespace BISolutions.ApplicationServices
{
    public class UsuarioAppService
    {
        private readonly BISolutionsDataContext _baseDatos;
        private readonly UsuarioDomainService _usuarioDomainService;
        private readonly CreateHash _createHash;
        public UsuarioAppService(BISolutionsDataContext _context, UsuarioDomainService usuarioDomainService, CreateHash createHash)
        {
            _baseDatos = _context;
            _usuarioDomainService = usuarioDomainService;
            _createHash = createHash;
        }
        public async Task<string> GetUsuarioApplicationService(int id)
        {
            var usuario = await _baseDatos.Usuarios.Include(q => q.Rol).FirstOrDefaultAsync(q => q.usuario_id == id);

            var respuestaDomainService = _usuarioDomainService.GetUsuarioDomainService(id, usuario);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            return null;
        }
        public async Task<string> PostUsuarioApplicationService(Usuario usuario)
        {
            Rol rol = await _baseDatos.Roles.FirstOrDefaultAsync(q => q.rol_id == usuario.usuario_rol_id);

            var respuestaDomainService = _usuarioDomainService.PostUsuarioDomainService(usuario, rol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            var hash = _createHash.Hash(usuario.usuario_contrasena);

            usuario.usuario_contrasena = hash.Password;
            usuario.usuario_sal = hash.Salt;

            _baseDatos.Usuarios.Add(usuario);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> PutUsuarioApplicationService(int id, Usuario usuario)
        {
            Rol rol = await _baseDatos.Roles.FirstOrDefaultAsync(q => q.rol_id == usuario.usuario_rol_id);

            var respuestaDomainService = _usuarioDomainService.PutUsuarioDomainService(id, usuario, rol);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            var hash = _createHash.Hash(usuario.usuario_contrasena);

            usuario.usuario_contrasena = hash.Password;
            usuario.usuario_sal = hash.Salt;

            _baseDatos.Entry(usuario).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return null;
        }
        public async Task<string> DeleteUsuarioApplicationService(int id)
        {
            var usuario = await _baseDatos.Usuarios.FindAsync(id);

            var respuestaDomainService = _usuarioDomainService.DeleteUsuarioDomainService(id, usuario);

            bool hayErrorDomainService = respuestaDomainService != null;

            if (hayErrorDomainService)
            {
                return respuestaDomainService;
            }

            _baseDatos.Usuarios.Remove(usuario);
            await _baseDatos.SaveChangesAsync();

            return null;
        }
    }
}
