using Extensions.ControllerExtensions;
using HRMSCore.Dtos.UserDtos;
using HRMSCore.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace HRMSCore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(
      IUserService UserService
    )
    {
      _userService = UserService;

    }
    [HttpGet]
    public Task<ActionResult<List<GetUser>>> GetAllUsers()
    {
      return this.ToResponseAsync(_userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public Task<ActionResult<GetUser>> GetUserById(int id)
    {
      return this.ToResponseAsync(_userService.GetUserById(id));
    }

    [HttpPost]
    public Task<ActionResult<GetUser>> AddUser(AddUser newUser)
    {
      return this.ToResponseAsync(_userService.AddUser(newUser));
    }

    [HttpDelete("{id}")]
    public Task<ActionResult<int>> DeleteUser(int id)
    {
      return this.ToResponseAsync(_userService.DeleteUser(id));
    }


  }
}