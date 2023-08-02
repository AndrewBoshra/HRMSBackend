using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRMSCore.Models;

namespace HRMSCore.Dtos.UserDtos
{
  public record UpdateUser(
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [EnumDataType(typeof(UserRole))]
    UserRole Role
  );
}