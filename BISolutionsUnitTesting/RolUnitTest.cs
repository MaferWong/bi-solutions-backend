using Microsoft.VisualStudio.TestTools.UnitTesting;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutionsUnitTesting
{
    [TestClass]
    public class RolUnitTest
    {
        [TestMethod]
        public void TestGetRolExiste()
        {
            var rol = new Rol();
            var id = new int();
            rol = null;

            var rolDomainService = new RolDomainService();
            var resultado = rolDomainService.GetRolDomainService(id, rol);

            Assert.AreEqual("El rol no existe.", resultado);
        }

        [TestMethod]
        public void TestPostRolDescripcionExiste()
        {
            var rol = new Rol();
            rol.rol_descripcion = "";

            var rolDomainService = new RolDomainService();
            var resultado = rolDomainService.PostRolDomainService(rol);

            Assert.AreEqual("Se necesita la descripción del rol.", resultado);
        }

        [TestMethod]
        public void TestPutRolDescripcionExiste()
        {
            var rol = new Rol();
            var id = new int();
            rol.rol_descripcion = "";

            var rolDomainService = new RolDomainService();
            var resultado = rolDomainService.PutRolDomainService(id, rol);

            Assert.AreEqual("Se necesita la descripción del rol.", resultado);
        }

        [TestMethod]
        public void TestDeleteRolExiste()
        {
            var rol = new Rol();
            var id = new int();
            rol = null;

            var rolDomainService = new RolDomainService();
            var resultado = rolDomainService.DeleteRolDomainService(id, rol);

            Assert.AreEqual("El rol no existe.", resultado);
        }

    }
}
