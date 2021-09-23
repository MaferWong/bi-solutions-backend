using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BISolutions.ApplicationServices;
using BISolutions.DataContext;
using BISolutions.Models;
using BISolutions.DTO;

namespace BISolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginAppService _loginAppService;
        public LoginController(LoginAppService loginAppService)
        {
            this._loginAppService = loginAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginSolicitudDTO loginSolicitud)
        {
            var login = await _loginAppService.Login(loginSolicitud);

            return Ok(login);
        }
    }
}
