using System.Collections.Generic;

namespace BISolutions.Models
{
    public class Usuario
    {
        public int usuario_id { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_correo { get; set; }
        public string usuario_contrasena { get; set; }
        public string usuario_sal { get; set; }
        public int usuario_rol_id { get; set; }
        public Rol Rol { get; set; }
    }
}
