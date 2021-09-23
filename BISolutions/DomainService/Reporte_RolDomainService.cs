using BISolutions.Models;

namespace BISolutions.DomainService
{
    public class Reporte_RolDomainService
    {
        public string GetReporteRolDomainService(int id, Reporte_Rol reporteRol)
        {
            if (reporteRol == null)
            {
                return "Esta asignación no existe.";
            }
            return null;
        }
        public string PostReporteRolDomainService(Reporte_Rol reporteRol)
        {
            if (reporteRol.rol_id == 0)
            {
                return "Se necesita el identificador del rol que desea asignar.";
            }
            if (reporteRol.reporte_id == 0)
            {
                return "Se necesita el identificador del reporte que desea asignar.";
            }
            return null;
        }
        public string PutReporteRolDomainService(int id, Reporte_Rol reporteRol, Rol rol, Reporte reporte)
        {
            if (id != reporteRol.reporte_rol_id)
            {
                return "Esta asignación no existe.";
            }
            if (rol == null)
            {
                return "El rol no existe.";
            }
            if (reporte == null)
            {
                return "El reporte no existe.";
            }
            return null;
        }
        public string DeleteReporteRolDomainService(int id, Reporte_Rol reporteRol)
        {
            if (reporteRol == null)
            {
                return "Esta asignación no existe.";
            }
            return null;
        }
    }
}
