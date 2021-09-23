using Microsoft.VisualStudio.TestTools.UnitTesting;
using BISolutions.DomainService;
using BISolutions.Models;

namespace BISolutionsUnitTesting
{
    [TestClass]
    public class UsuarioUnitTest
    {
        [TestMethod]
        public void TestGetUsuarioExiste()
        {
            var usuario = new Usuario();
            var id = new int();
            usuario = null;

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.GetUsuarioDomainService(id, usuario);

            Assert.AreEqual("El usuario no existe.", resultado);
        }

        [TestMethod]
        public void TestPostUsuarioNombreExiste()
        {
            var usuario = new Usuario();
            var rol = new Rol();

            usuario.usuario_nombre = "";

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.PostUsuarioDomainService(usuario, rol);

            Assert.AreEqual("Se necesita el nombre del usuario.", resultado);
        }

        [TestMethod]
        public void TestPostUsuarioCorreoExiste()
        {
            var usuario = new Usuario();
            var rol = new Rol();

            usuario.usuario_correo = "";

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.PostUsuarioDomainService(usuario, rol);

            Assert.AreEqual("Se necesita el correo del usuario.", resultado);
        }

        [TestMethod]
        public void TestPostUsuarioContrasenaExiste()
        {
            var usuario = new Usuario();
            var rol = new Rol();

            usuario.usuario_contrasena = "";

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.PostUsuarioDomainService(usuario, rol);

            Assert.AreEqual("Se necesita la contraseña del usuario.", resultado);
        }

        [TestMethod]
        public void TestPutRolUsuarioExiste()
        {
            var usuario = new Usuario();
            var rol = new Rol();
            var id = new int();
            rol = null;

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.PutUsuarioDomainService(id, usuario, rol);

            Assert.AreEqual("Se necesita el rol del usuario.", resultado);
        }

        [TestMethod]
        public void TestPutUsuarioNombreExiste()
        {
            var usuario = new Usuario();
            var rol = new Rol();
            var id = new int();
            usuario.usuario_nombre = "";

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.PutUsuarioDomainService(id, usuario, rol);

            Assert.AreEqual("Se necesita el nombre del usuario.", resultado);
        }

        [TestMethod]
        public void TestPutUsuarioCorreoExiste()
        {
            var usuario = new Usuario();
            var rol = new Rol();
            var id = new int();
            usuario.usuario_correo = "";

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.PutUsuarioDomainService(id, usuario, rol);

            Assert.AreEqual("Se necesita el correo del usuario.", resultado);
        }

        [TestMethod]
        public void TestPutUsuarioContrasenaExiste()
        {
            var usuario = new Usuario();
            var rol = new Rol();
            var id = new int();
            usuario.usuario_contrasena = "";

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.PutUsuarioDomainService(id, usuario, rol);

            Assert.AreEqual("Se necesita la contraseña del usuario.", resultado);
        }

        [TestMethod]
        public void TestDeleteUsuarioExiste()
        {
            var usuario = new Usuario();
            var id = new int();
            usuario = null;

            var usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.DeleteUsuarioDomainService(id, usuario);

            Assert.AreEqual("El usuario no existe.", resultado);
        }
    }
}
