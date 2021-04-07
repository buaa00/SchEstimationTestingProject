using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchEstimationTestingProject.Core.Users.ApplicationDTOs;
using SchEstimationTestingProject.Core.Users.ApplicationServices;

namespace SchEstimationTestingProject.Apps.WebApi.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public async Task<IActionResult> CreateNewUser([FromBody] CreateNewUserReqDTO data)
        {
            try
            {
                var response = await _userService.CreateNewUserAsync(data);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    Error = e.Message
                });
            }
        }
    }
}
