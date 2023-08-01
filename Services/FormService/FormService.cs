using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Errors;
using HRMS.Data;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Dtos.FormDtos;
using HRMSCore.Errors;
using HRMSCore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HRMSCore.Services.FormService
{
  public class FormService : IFormService
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public FormService(IMapper mapper, ApplicationDbContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    async Task<Result<GetForm>> IFormService.AddForm(AddForm newForm)
    {
      List<int> fieldsIds = newForm.Steps
                                  .SelectMany(step =>
                                              step.Rows.SelectMany(row => row.Fields.Select(field => field.FieldId)))
                                  .ToList();

      List<Field> fields = await _context.Fields
                                          .Where(field => fieldsIds.Contains(field.Id))
                                          .ToListAsync();

      if (fields.Count != fieldsIds.Count)
      {
        List<int> notFoundFieldsIds = fieldsIds.Except(fields.Select(field => field.Id)).ToList();
        return Result<GetForm>.Fail(
           new DomainError(
            $"Fields with ids {string.Join(", ", notFoundFieldsIds)} not found"
          )
        );
      }

      Form form = _mapper.Map<Form>(newForm);
      form.UpdateLayout();

      _context.Forms.Add(form);
      await _context.SaveChangesAsync();

      return Result<GetForm>.Ok(_mapper.Map<GetForm>(form));

    }

    async Task<Result<int>> IFormService.DeleteForm(int id)
    {
      int deleted = await _context.Forms.Where(f => f.Id == id).ExecuteDeleteAsync();
      if (deleted == 0)
      {
        return Result<int>.Fail(
           new EntityNotFoundError(
            $"Form with id {id} not found"
          )
        );
      }
      return Result<int>.Ok(id);
    }

    async Task<Result<List<GetForm>>> IFormService.GetAllForms()
    {
      List<Form> forms = await _context.Forms.Include(form => form.Steps.OrderBy(step => step.Order))
                                              .ThenInclude(step => step.Rows.OrderBy(row => row.Order))
                                              .ThenInclude(row => row.Fields.OrderBy(field => field.Order))
                                              .ThenInclude(field => field.Field)
                                              .ToListAsync();
      return Result<List<GetForm>>.Ok(_mapper.Map<List<GetForm>>(forms));
    }

    async Task<Result<GetForm>> IFormService.GetFormById(int id)
    {
      Form? form = await _context.Forms.Include(form => form.Steps.OrderBy(step => step.Order))
                                        .ThenInclude(step => step.Rows.OrderBy(row => row.Order))
                                        .ThenInclude(row => row.Fields.OrderBy(field => field.Order))
                                        .ThenInclude(field => field.Field)
                                        .FirstOrDefaultAsync(form => form.Id == id);
      if (form == null)
      {
        return Result<GetForm>.Fail(
           new EntityNotFoundError(
            $"Form with id {id} not found"
          )
        );
      }
      return Result<GetForm>.Ok(_mapper.Map<GetForm>(form));
    }
  }
}