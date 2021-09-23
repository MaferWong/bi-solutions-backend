using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BISolutions.Models;
using BISolutions.DataContext;
using BISolutions.DTO;
using BISolutions.Funcion_Hash;

namespace BISolutions.DomainService
{
    public class LoginDomainService
    {
        private readonly BISolutionsDataContext _context;
        private readonly CreateHash _createHash;
        public LoginDomainService(BISolutionsDataContext context, CreateHash createHash)
        {
            this._context = context;
            this._createHash = createHash;
        }
        public async Task<Usuario> EncontrarUsuario(LoginSolicitudDTO loginSolicitud)
        {
            var usuario = await _context.Usuarios.Include(q => q.Rol).FirstOrDefaultAsync(x => x.usuario_correo == loginSolicitud.login_correo);
            if (usuario == null)
            {
                return null;
            }

            var verificacion = _createHash.CheckHash(loginSolicitud.login_contrasena,usuario.usuario_contrasena,usuario.usuario_sal);
            if (verificacion == false)
            {
                return null;
            }

            return usuario;
        }
    }
}
