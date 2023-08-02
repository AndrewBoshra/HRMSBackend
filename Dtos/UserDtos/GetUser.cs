using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Models;

namespace HRMSCore.Dtos.UserDtos
{
  public record GetUser(
    int Id,
    string Email,
    UserRole Role
  );
}