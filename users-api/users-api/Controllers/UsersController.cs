using Microsoft.AspNetCore.Mvc;
using users_api.BLL.Interfaces;
using users_api.BLL.Services;

namespace users_api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private UserService _service;
        private ILoggerManager _loggerManager;
        public UsersController(UserService service, ILoggerManager loggerManager)
        {
            _service = service;
            _loggerManager = loggerManager;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var companies = _service.GetAll(false);
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetUsers)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
