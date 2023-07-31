using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Models;

namespace HRMSCore.Services.DataSourceService
{
  public interface IDataSourceService
  {
    Task<Result<List<GetDataSource>>> GetAllDataSources();
    Task<Result<GetDataSource>> GetDataSourceById(int id);
    Task<Result<GetDataSource>> AddDataSource(AddDataSource newDataSource);
    Task<Result<GetDataSource>> UpdateDataSource(int id, UpdateDataSource updatedDataSource);
    Task<Result<int>> DeleteDataSource(int id);

  }
}