using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Errors;

namespace HRMSCore.Errors
{
  public class DomainError : BaseError
  {
    public DomainError(string message) : base(message)
    { }
  }
}