using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BISolutions.DTO
{
    public class LoginRespuestaDTO
    {
        public string login_correo { get; set; }
        public string login_token { get; set; }
        public string login_usuario_rol { get; set; }
        public int login_usuario_rol_id { get; set; }
    }
}
