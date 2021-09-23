using Microsoft.VisualStudio.TestTools.UnitTesting;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutionsUnitTesting
{
    [TestClass]
    public class ReporteRolUnitTest
    {
        [TestMethod]
        public void TestGetReporteRolExiste()
        {
            var reporteRol = new Reporte_Rol();
            var id = new int();
            reporteRol = null;

            var reporteRolDomainService = new Reporte_RolDomainService();
            var resultado = reporteRolDomainService.GetReporteRolDomainService(id, reporteRol);

            Assert.AreEqual("Esta asignación no existe.", resultado);
        }
        
        [TestMethod]
        public void TestPostRolIdExiste()
        {
            var reporteRol = new Reporte_Rol();
            reporteRol.rol_id = 0;
            reporteRol.reporte_id = 1;

            var reporteRolDomainService = new Reporte_RolDomainService();
            var resultado = reporteRolDomainService.PostReporteRolDomainService(reporteRol);

            Assert.AreEqual("Se necesita el identificador del rol que desea asignar.", resultado);
        }

        [TestMethod]
        public void TestPostReporteIdExiste()
        {
            var reporteRol = new Reporte_Rol();
            reporteRol.reporte_id = 0;
            reporteRol.rol_id = 1;

            var reporteRolDomainService = new Reporte_RolDomainService();
            var resultado = reporteRolDomainService.PostReporteRolDomainService(reporteRol);

            Assert.AreEqual("Se necesita el identificador del reporte que desea asignar.", resultado);
        }

        [TestMethod]
        public void TestPutRolExiste()
        {
            var reporteRol = new Reporte_Rol();
            var rol = new Rol();
            var reporte = new Reporte();
            var id = new int();
            rol = null;

            var reporteRolDomainService = new Reporte_RolDomainService();
            var resultado = reporteRolDomainService.PutReporteRolDomainService(id, reporteRol, rol, reporte);

            Assert.AreEqual("El rol no existe.", resultado);
        }

        [TestMethod]
        public void TestPutReporteExiste()
        {
            var reporteRol = new Reporte_Rol();
            var rol = new Rol();
            var reporte = new Reporte();
            var id = new int();
            reporte = null;

            var reporteRolDomainService = new Reporte_RolDomainService();
            var resultado = reporteRolDomainService.PutReporteRolDomainService(id, reporteRol, rol, reporte);

            Assert.AreEqual("El reporte no existe.", resultado);
        }

        [TestMethod]
        public void TestDeleteReporteRolExiste()
        {
            var reporteRol = new Reporte_Rol();
            var id = new int();
            reporteRol = null;

            var reporteRolDomainService = new Reporte_RolDomainService();
            var resultado = reporteRolDomainService.DeleteReporteRolDomainService(id, reporteRol);

            Assert.AreEqual("Esta asignación no existe.", resultado);
        }
    }
}
