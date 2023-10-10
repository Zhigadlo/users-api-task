using Contracts.Service;
using Entities.DataTransferObjects;
using Entities.FilterModels;
using Entities.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace users_api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private IServiceManager _serviceManager;
        public UsersController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{PageNumber}/{PageSize}/")]
        public IActionResult GetPage([FromRoute] PaginationModel userPaginationModel, [FromQuery] UserFilterModel userFilter)
        {
            var users = _serviceManager.User.GetPage(userPaginationModel, userFilter);
            return Ok(users);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var companies = _serviceManager.User.GetAll(false);
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userDto = _serviceManager.User.Get(id, false);
            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserForCreationDTO userForCreationDTO)
        {
            var result = _serviceManager.User.Create(userForCreationDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _serviceManager.User.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserForUpdateDTO userForUpdateDTO)
        {
            var result = _serviceManager.User.Update(userForUpdateDTO);
            return Ok(result);
        }
    }
}
