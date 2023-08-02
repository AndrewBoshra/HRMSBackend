using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Errors;

namespace HRMSCore.Errors
{
  public class ConflictError : BaseError
  {
    public ConflictError(string message) : base(message)
    { }
  }
}