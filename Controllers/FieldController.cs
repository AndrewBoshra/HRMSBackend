using Extensions.ControllerExtensions;
using HRMSCore.Dtos.FieldDtos;
using HRMSCore.Services.FieldService;
using Microsoft.AspNetCore.Mvc;

namespace HRMSCore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FieldController : ControllerBase
  {
    private readonly IFieldService _fieldService;

    public FieldController(
      IFieldService FieldService
    )
    {
      _fieldService = FieldService;

    }
    [HttpGet]
    public Task<ActionResult<List<GetField>>> GetAllFields()
    {
      return this.ToResponseAsync(_fieldService.GetAllFields());
    }

    [HttpGet("{id}")]
    public Task<ActionResult<GetField>> GetFieldById(int id)
    {
      return this.ToResponseAsync(_fieldService.GetFieldById(id));
    }

    [HttpPost]
    public Task<ActionResult<GetField>> AddField(AddField newField)
    {
      return this.ToResponseAsync(_fieldService.AddField(newField));
    }

    [HttpDelete("{id}")]
    public Task<ActionResult<int>> DeleteField(int id)
    {
      return this.ToResponseAsync(_fieldService.DeleteField(id));
    }

    [HttpPut("{id}")]
    public Task<ActionResult<GetField>> UpdateField(int id, UpdateField updatedField)
    {
      return this.ToResponseAsync(_fieldService.UpdateField(id, updatedField));
    }
  }
}