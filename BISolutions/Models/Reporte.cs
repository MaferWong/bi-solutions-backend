using System.Collections.Generic;

namespace BISolutions.Models
{
    public class Reporte
    {
        public int reporte_id { get; set; }
        public string reporte_descripcion { get; set; }
        public string reporte_URL { get; set; }
        public string reporte_activo { get; set; }
        public List<Reporte_Rol>Reportes_Roles { get; set; }
    }
}
