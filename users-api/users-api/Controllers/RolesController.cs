using Contracts.Service;
using Entities.DataTransferObjects;
using Entities.ErrorModels;
using Microsoft.AspNetCore.Mvc;

namespace users_api.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : Controller
    {
        private IServiceManager _serviceManager;

        public RolesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult GetAll()
        {
            var roles = _serviceManager.Role.GetAll(false);
            return Ok(roles);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Get(int id)
        {
            var role = _serviceManager.Role.Get(id, false);
            return Ok(role);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Create([FromBody] RoleForCreationDTO roleForCreationDTO)
        {
            var role = _serviceManager.Role.Create(roleForCreationDTO);
            return Ok(role);
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 400)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Update([FromBody] RoleForUpdateDTO roleForUpdateDTO)
        {
            var role = _serviceManager.Role.Update(roleForUpdateDTO);
            return Ok(role);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        public IActionResult Delete(int id)
        {
            var role = _serviceManager.Role.Delete(id);
            return Ok(role);
        }
    }
}
