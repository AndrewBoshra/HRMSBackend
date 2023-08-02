using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMSCore.Dtos.UserDtos;
using HRMSCore.Models;

namespace HRMSCore.Services.UserService
{
  public interface IUserService
  {
    Task<Result<List<GetUser>>> GetAllUsers();
    Task<Result<GetUser>> GetUserById(int id);
    Task<Result<GetUser>> AddUser(AddUser newUser);
    Task<Result<GetUser>> UpdateUser(int id, UpdateUser updatedUser);
    Task<Result<int>> DeleteUser(int id);
  }
}