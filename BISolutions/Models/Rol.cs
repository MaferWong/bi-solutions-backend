using System.Collections.Generic;

namespace BISolutions.Models
{
    public class Rol
    {
        public int rol_id { get; set; }
        public string rol_descripcion { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Reporte_Rol> Reportes_Roles { get; set; }
    }
}
