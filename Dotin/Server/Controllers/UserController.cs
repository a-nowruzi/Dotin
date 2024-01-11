using Common.DTOs;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dotin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser iUser)
        {
            _user = iUser;
        }

        [HttpGet]
        public async Task<OperationResult<List<UserDto>>> Get()
        {
            return await _user.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            OperationResult<UserDto> result = await _user.GetUserInfo(id);
            return StatusCode((int)result.ResponseCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto user)
        {
            OperationResult<bool> result = await _user.AddUser(user);
            return StatusCode((int)result.ResponseCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserDto user)
        {
            OperationResult<bool> result = await _user.UpdateUser(user);
            return StatusCode((int)result.ResponseCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OperationResult<bool> result = await _user.DeleteUser(id);
            return StatusCode((int)result.ResponseCode, result);
        }

    }
}
