using HRMSCore.Errors;
using HRMSCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Extensions.ControllerExtensions
{

  static class ControllerExtensions
  {
    public static async Task<ActionResult<T>> ToResponseAsync<T>(this ControllerBase controller, Task<Result<T>> resultTask)
    {

      var result = await resultTask;

      if (result.IsOk())
      {
        return controller.Ok(result.Success);
      }

      var error = result.Error!;

      if (error is DomainError)
      {
        return controller.BadRequest(error);
      }
      if (error is ConflictError)
      {
        return controller.Conflict(error);
      }
      if (error is EntityNotFoundError)
      {
        return controller.NotFound(error);
      }

      return controller.StatusCode(500, error);
    }
  }
}