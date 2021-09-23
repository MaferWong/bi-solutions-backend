using Microsoft.VisualStudio.TestTools.UnitTesting;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutionsUnitTesting
{
    [TestClass]
    public class ReporteUnitTest
    {
        [TestMethod]
        public void TestGetReporteExiste()
        {
            var reporte = new Reporte();
            var id = new int();
            reporte = null;

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.GetReporteDomainService(id, reporte);

            Assert.AreEqual("El reporte no existe.", resultado);
        }

        [TestMethod]
        public void TestPostReporteDescripcionExiste()
        {
            var reporte = new Reporte();
            reporte.reporte_descripcion = "";

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.PostReporteDomainService(reporte);

            Assert.AreEqual("Se necesita la descripción del reporte.", resultado);
        }

        [TestMethod]
        public void TestPostReporteURLExiste()
        {
            var reporte = new Reporte();
            reporte.reporte_URL = "";

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.PostReporteDomainService(reporte);

            Assert.AreEqual("Se necesita el enlace del reporte.", resultado);
        }

        [TestMethod]
        public void TestPostReporteEstadoExiste()
        {
            var reporte = new Reporte();
            reporte.reporte_activo = "";

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.PostReporteDomainService(reporte);

            Assert.AreEqual("Se necesita el estado del reporte.", resultado);
        }

        [TestMethod]
        public void TestPutReporteDescripcionExiste()
        {
            var reporte = new Reporte();
            var id = new int();
            reporte.reporte_descripcion = "";

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.PutReporteDomainService(id, reporte);

            Assert.AreEqual("Se necesita la descripción del reporte.", resultado);
        }

        [TestMethod]
        public void TestPutReporteURLExiste()
        {
            var reporte = new Reporte();
            var id = new int();
            reporte.reporte_URL = "";

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.PutReporteDomainService(id, reporte);

            Assert.AreEqual("Se necesita el enlace del reporte.", resultado);
        }

        [TestMethod]
        public void TestPutReporteEstadoExiste()
        {
            var reporte = new Reporte();
            var id = new int();
            reporte.reporte_activo = "";

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.PutReporteDomainService(id, reporte);

            Assert.AreEqual("Se necesita el estado del reporte.", resultado);
        }

        [TestMethod]
        public void TestDeleteReporteExiste()
        {
            var reporte = new Reporte();
            var id = new int();
            reporte = null;

            var reporteDomainService = new ReporteDomainService();
            var resultado = reporteDomainService.DeleteReporteDomainService(id, reporte);

            Assert.AreEqual("El reporte no existe.", resultado);
        }
    }
}
