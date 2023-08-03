using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Errors;
using HRMS.Data;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Dtos.UserDtos;
using HRMSCore.Errors;
using HRMSCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HRMSCore.Services.UserService
{
  public class UserService : IUserService
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public UserService(IMapper mapper, ApplicationDbContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    async Task<Result<GetUser>> IUserService.AddUser(AddUser newUser)
    {
      User user = _mapper.Map<User>(newUser);

      bool isEmailTaken = await _context.Users.AnyAsync(User => User.Email == newUser.Email);

      if (isEmailTaken)
        return Result<GetUser>.Fail(new DomainError($"Email {newUser.Email} is already taken"));

      await _context.Users.AddAsync(user);

      await _context.SaveChangesAsync();

      return Result<GetUser>.Ok(_mapper.Map<GetUser>(user));

    }

    async Task<Result<int>> IUserService.DeleteUser(int id)
    {
      int deleted = await _context.Users.Where(f => f.Id == id).ExecuteDeleteAsync();
      if (deleted == 0)
      {
        return Result<int>.Fail(
           new EntityNotFoundError(
            $"User with id {id} not found"
          )
        );
      }
      return Result<int>.Ok(id);
    }

    async Task<Result<List<GetUser>>> IUserService.GetAllUsers()
    {
      List<User> Users = await _context.Users.ToListAsync();
      return Result<List<GetUser>>.Ok(_mapper.Map<List<GetUser>>(Users));
    }

    async Task<Result<GetUser>> IUserService.GetUserById(int id)
    {
      User? User = await _context.Users.FirstOrDefaultAsync(User => User.Id == id);
      if (User == null)
      {
        return Result<GetUser>.Fail(
           new EntityNotFoundError(
            $"User with id {id} not found"
          )
        );
      }
      return Result<GetUser>.Ok(_mapper.Map<GetUser>(User));
    }

    async Task<Result<GetUser>> IUserService.UpdateUser(int id, UpdateUser updatedUser)
    {
      User? user = await _context.Users.FirstOrDefaultAsync(User => User.Id == id);
      if (user == null)
      {
        return Result<GetUser>.Fail(
           new EntityNotFoundError(
            $"User with id {id} not found"
          )
        );
      }

      var isEmailTaken = await _context.Users.AnyAsync(User => User.Email == updatedUser.Email && User.Id != id);
      if (isEmailTaken)
      {
        return Result<GetUser>.Fail(
           new DomainError(
            $"Email {updatedUser.Email} is already taken"
          )
        );
      }

      _mapper.Map(updatedUser, user);
      await _context.SaveChangesAsync();
      return Result<GetUser>.Ok(_mapper.Map<GetUser>(user));
    }
  }
}