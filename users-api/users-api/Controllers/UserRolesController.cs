using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace users_api.Controllers
{
    [ApiController]
    [Route("api/user_roles")]
    public class UserRolesController : Controller
    {
        private IServiceManager _serviceManager;
        public UserRolesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userRole = _serviceManager.UserRole.Get(id, false);
            return Ok(userRole);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var userRoles = _serviceManager.UserRole.GetAll(false);
            return Ok(userRoles);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserRoleForCreationDTO userRoleForCreationDTO)
        {
            var userRole = _serviceManager.UserRole.Create(userRoleForCreationDTO);
            return Ok(userRole);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userRole = _serviceManager.UserRole.Delete(id);
            return Ok(userRole);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserRoleForUpdateDTO userRoleForUpdateDTO)
        {
            var userRole = _serviceManager.UserRole.Update(userRoleForUpdateDTO);
            return Ok(userRole);
        }
    }
}
