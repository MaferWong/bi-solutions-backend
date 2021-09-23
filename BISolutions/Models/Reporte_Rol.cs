namespace BISolutions.Models
{
    public class Reporte_Rol
    {
        public int reporte_rol_id { get; set; }
        public int rol_id { get; set; }
        public Rol Rol { get; set; }
        public int reporte_id { get; set; }
        public Reporte Reporte { get; set; }
    }
}
