using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Dtos.FieldDtos;
using HRMSCore.Models;

namespace HRMSCore.Services.FieldService
{
  public interface IFieldService
  {
    Task<Result<List<GetField>>> GetAllFields();
    Task<Result<GetField>> GetFieldById(int id);
    Task<Result<GetField>> AddField(AddField newField);
    Task<Result<GetField>> UpdateField(int id, UpdateField updatedField);
    Task<Result<int>> DeleteField(int id);

  }
}