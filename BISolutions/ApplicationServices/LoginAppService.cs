using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BISolutions.DataContext;
using BISolutions.DomainService;
using BISolutions.Models;
using BISolutions.DTO;

namespace BISolutions.ApplicationServices
{
    public class LoginAppService
    {
        private readonly LoginRespuestaDTO _loginRespuestaDTO;
        private readonly LoginDomainService _loginDomainService;
        private readonly CreateToken _createToken;

        public LoginAppService(LoginRespuestaDTO loginRespuestaDTO, LoginDomainService loginDomainService, CreateToken createToken)
        {
            this._loginDomainService = loginDomainService;
            this._loginRespuestaDTO = loginRespuestaDTO;
            this._createToken = createToken;
        }

        public async Task<LoginRespuestaDTO> Login(LoginSolicitudDTO loginSolicitud)
        {
            var usuario = await _loginDomainService.EncontrarUsuario(loginSolicitud);

            if (usuario == null)
            {
                return null;
            }
            _loginRespuestaDTO.login_correo = usuario.usuario_correo;
            _loginRespuestaDTO.login_usuario_rol = usuario.Rol.rol_descripcion;
            _loginRespuestaDTO.login_usuario_rol_id = usuario.Rol.rol_id;
            _loginRespuestaDTO.login_token = _createToken.CreateJWT(usuario);

            return _loginRespuestaDTO;
        }
    }
}
