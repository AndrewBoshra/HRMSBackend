using Extensions.ControllerExtensions;
using HRMSCore.Dtos.FormDtos;
using HRMSCore.Services.FormService;
using Microsoft.AspNetCore.Mvc;

namespace HRMSCore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FormController : ControllerBase
  {
    private readonly IFormService _formService;

    public FormController(
      IFormService FormService
    )
    {
      _formService = FormService;

    }
    [HttpGet]
    public Task<ActionResult<List<GetForm>>> GetAllForms()
    {
      return this.ToResponseAsync(_formService.GetAllForms());
    }

    [HttpGet("{id}")]
    public Task<ActionResult<GetFormDetails>> GetFormById(int id)
    {
      return this.ToResponseAsync(_formService.GetFormById(id));
    }

    [HttpPost]
    public Task<ActionResult<GetFormDetails>> AddForm(AddForm newForm)
    {
      return this.ToResponseAsync(_formService.AddForm(newForm));
    }

    [HttpDelete("{id}")]
    public Task<ActionResult<int>> DeleteForm(int id)
    {
      return this.ToResponseAsync(_formService.DeleteForm(id));
    }


  }
}