using HRMSCore.Models;

namespace Errors;

public class BaseError
{
  public string Message { get; private set; }

  public BaseError(string message)
  {
    Message = message;
  }


  public static implicit operator string(BaseError error)
  {
    return error.Message;
  }


}