using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMSCore.Dtos.FormDtos;
using HRMSCore.Models;

namespace HRMSCore.Services.FormService
{
  public interface IFormService
  {
    Task<Result<List<GetForm>>> GetAllForms();
    Task<Result<GetForm>> GetFormById(int id);
    Task<Result<GetForm>> AddForm(AddForm newForm);
    Task<Result<int>> DeleteForm(int id);
  }
}