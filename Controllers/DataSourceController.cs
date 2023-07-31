using Extensions.ControllerExtensions;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Services.DataSourceService;
using Microsoft.AspNetCore.Mvc;

namespace HRMSCore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DataSourceController : ControllerBase
  {
    private readonly IDataSourceService _dataSourceService;

    public DataSourceController(
      IDataSourceService dataSourceService
    )
    {
      _dataSourceService = dataSourceService;

    }
    [HttpGet]
    public Task<ActionResult<List<GetDataSource>>> GetAllDataSources()
    {
      return this.ToResponseAsync(_dataSourceService.GetAllDataSources());
    }

    [HttpGet("{id}")]
    public Task<ActionResult<GetDataSource>> GetDataSourceById(int id)
    {
      return this.ToResponseAsync(_dataSourceService.GetDataSourceById(id));
    }

    [HttpPost]
    public Task<ActionResult<GetDataSource>> AddDataSource(AddDataSource newDataSource)
    {
      return this.ToResponseAsync(_dataSourceService.AddDataSource(newDataSource));
    }

    [HttpDelete("{id}")]
    public Task<ActionResult<int>> DeleteDataSource(int id)
    {
      return this.ToResponseAsync(_dataSourceService.DeleteDataSource(id));
    }

    [HttpPut("{id}")]
    public Task<ActionResult<GetDataSource>> UpdateDataSource(int id, UpdateDataSource updatedDataSource)
    {
      return this.ToResponseAsync(_dataSourceService.UpdateDataSource(id, updatedDataSource));
    }
  }
}