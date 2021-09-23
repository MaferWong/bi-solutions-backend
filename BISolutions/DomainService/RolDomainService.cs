using BISolutions.Models;

namespace BISolutions.DomainService
{
    public class RolDomainService
    {
        public string GetRolDomainService(int id, Rol rol)
        {
            if (rol == null)
            {
                return "El rol no existe.";
            }
            return null;
        }
        public string PostRolDomainService(Rol rol)
        {
            if (rol.rol_descripcion == "")
            {
                return "Se necesita la descripción del rol.";
            }
            return null;
        }
        public string PutRolDomainService(int id, Rol rol)
        {
            if (id != rol.rol_id)
            {
                return "El rol no existe.";
            }
            if (rol.rol_descripcion == "")
            {
                return "Se necesita la descripción del rol.";
            }
            return null;
        }
        public string DeleteRolDomainService(int id, Rol rol)
        {
            if (rol == null)
            {
                return "El rol no existe.";
            }
            return null;
        }
    }
}
