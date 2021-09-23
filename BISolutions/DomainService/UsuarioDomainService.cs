using BISolutions.Models;

namespace BISolutions.DomainService
{
    public class UsuarioDomainService
    {
        public string GetUsuarioDomainService(int id, Usuario usuario)
        {
            if (usuario == null)
            {
                return "El usuario no existe.";
            }
            return null;
        }
        public string PostUsuarioDomainService(Usuario usuario, Rol rol)
        {
            if (usuario.usuario_nombre == "")
            {
                return "Se necesita el nombre del usuario.";
            }
            if (usuario.usuario_correo == "")
            {
                return "Se necesita el correo del usuario.";
            }
            if (usuario.usuario_contrasena == "")
            {
                return "Se necesita la contraseña del usuario.";
            }
            if (rol == null)
            {
                return "Se necesita el rol del usuario.";
            }

            return null;
        }
        public string PutUsuarioDomainService(int id, Usuario usuario, Rol rol)
        {
            if (id != usuario.usuario_id)
            {
                return "El usuario no existe.";
            }
            if (usuario.usuario_nombre == "")
            {
                return "Se necesita el nombre del usuario.";
            }
            if (usuario.usuario_correo == "")
            {
                return "Se necesita el correo del usuario.";
            }
            if (usuario.usuario_contrasena == "")
            {
                return "Se necesita la contraseña del usuario.";
            }
            if (rol == null)
            {
                return "Se necesita el rol del usuario.";
            }
            return null;
        }
        public string DeleteUsuarioDomainService(int id, Usuario usuario)
        {
            if (usuario == null)
            {
                return "El usuario no existe.";
            }
            return null;
        }
    }
}
