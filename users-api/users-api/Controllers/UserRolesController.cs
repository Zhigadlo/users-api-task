using Contracts.Service;
using Entities.DataTransferObjects;
using Entities.ErrorModels;
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
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Get(int id)
        {
            var userRole = _serviceManager.UserRole.Get(id, false);
            return Ok(userRole);
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult GetAll()
        {
            var userRoles = _serviceManager.UserRole.GetAll(false);
            return Ok(userRoles);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Create([FromBody] UserRoleForCreationDTO userRoleForCreationDTO)
        {
            var userRole = _serviceManager.UserRole.Create(userRoleForCreationDTO);
            return Ok(userRole);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Delete(int id)
        {
            var userRole = _serviceManager.UserRole.Delete(id);
            return Ok(userRole);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Update([FromBody] UserRoleForUpdateDTO userRoleForUpdateDTO)
        {
            var userRole = _serviceManager.UserRole.Update(userRoleForUpdateDTO);
            return Ok(userRole);
        }
    }
}
