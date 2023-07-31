using Errors;

namespace HRMSCore.Errors
{
  public class EntityNotFoundError : BaseError
  {
    public EntityNotFoundError(string message) : base(message)
    { }
  }
}