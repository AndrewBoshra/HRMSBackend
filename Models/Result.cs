using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Errors;

namespace HRMSCore.Models
{
  public record Result<T>
  {
    public T? Success { get; set; } = default;
    public BaseError? Error { get; set; } = default;

    private Result(T success)
    {
      Success = success;
    }

    private Result(BaseError error)
    {
      Error = error;
    }


    public static Result<T> Ok(T success)
    {
      return new Result<T>(success);
    }

    public static Result<T> Fail(BaseError error)
    {
      return new Result<T>(error);
    }


    public bool IsOk()
    {
      return Error == null;
    }

    public bool IsFail()
    {
      return Error != null;
    }

  }

}