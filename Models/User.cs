using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCore.Models
{
  public class User : BaseEntity
  {
    public UserRole Role { get; set; }
    public string Email { get; set; } = null!;
  }
}