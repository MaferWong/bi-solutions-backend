using BISolutions.Models;

namespace BISolutions.DomainService
{
    public class ReporteDomainService
    {
        public string GetReporteDomainService(int id, Reporte reporte)
        {
            if (reporte == null)
            {
                return "El reporte no existe.";
            }
            return null;
        }
        public string PostReporteDomainService(Reporte reporte)
        {
            if (reporte.reporte_descripcion == "")
            {
                return "Se necesita la descripción del reporte.";
            }
            if (reporte.reporte_URL == "")
            {
                return "Se necesita el enlace del reporte.";
            }
            if (reporte.reporte_activo == "")
            {
                return "Se necesita el estado del reporte.";
            }
            return null;
        }
        public string PutReporteDomainService(int id, Reporte reporte)
        {
            if (id != reporte.reporte_id)
            {
                return "El reporte no existe.";
            }
            if (reporte.reporte_descripcion == "")
            {
                return "Se necesita la descripción del reporte.";
            }
            if (reporte.reporte_URL == "")
            {
                return "Se necesita el enlace del reporte.";
            }
            if (reporte.reporte_activo == "")
            {
                return "Se necesita el estado del reporte.";
            }
            return null;
        }
        public string DeleteReporteDomainService(int id, Reporte reporte)
        {
            if (reporte == null)
            {
                return "El reporte no existe.";
            }
            return null;
        }
    }
}
