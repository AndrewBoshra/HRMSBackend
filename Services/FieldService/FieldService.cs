using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Errors;
using HRMS.Data;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Dtos.FieldDtos;
using HRMSCore.Errors;
using HRMSCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMSCore.Services.FieldService
{
  public class FieldService : IFieldService
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public FieldService(IMapper mapper, ApplicationDbContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task<Result<GetField>> AddField(AddField newField)
    {

      DataSource? dataSource = null;

      if (newField.DataSourceId != null)
      {
        dataSource = await _context.DataSources.FirstOrDefaultAsync(x => x.Id == newField.DataSourceId);
        if (dataSource == null)
          return Result<GetField>.Fail(
            new DomainError($"Invalid Data source id : {newField.DataSourceId}.")
          );
      }

      Field field = _mapper.Map<Field>(newField);
      field.DataSource = dataSource;

      _context.Fields.Add(field);
      await _context.SaveChangesAsync();

      return Result<GetField>.Ok(_mapper.Map<GetField>(field));


    }

    public async Task<Result<int>> DeleteField(int id)
    {
      int deletedRows = await _context.Fields.Where(
        x => x.Id == id
      ).ExecuteDeleteAsync();

      if (deletedRows == 0)
      {
        return Result<int>.Fail(
          new EntityNotFoundError($"Field with id {id} not found.")
        );
      }

      return Result<int>.Ok(id);
    }

    public async Task<Result<List<GetField>>> GetAllFields()
    {
      var fields = _mapper.Map<List<GetField>>(await _context.Fields.Include(x => x.DataSource).ToListAsync());
      return Result<List<GetField>>.Ok(fields);
    }

    public async Task<Result<GetField>> GetFieldById(int id)
    {
      var field = await _context.Fields.Include(x => x.DataSource).FirstOrDefaultAsync(x => x.Id == id);
      if (field == null)
        return Result<GetField>.Fail(
          new EntityNotFoundError($"Field with id {id} not found.")
        );

      return Result<GetField>.Ok(_mapper.Map<GetField>(field));
    }

    public async Task<Result<GetField>> UpdateField(int id, UpdateField updatedField)
    {
      var field = await _context.Fields.FirstOrDefaultAsync(x => x.Id == id);
      if (field == null)
        return Result<GetField>.Fail(
          new EntityNotFoundError($"Field with id {id} not found.")
        );
      Console.WriteLine("updatedField.DataSourceId\n\n\n");

      DataSource? dataSource = field.DataSource;

      if (updatedField.DataSourceId != null && updatedField.DataSourceId != field.DataSource?.Id)
      {
        dataSource = await _context.DataSources.FirstOrDefaultAsync(x => x.Id == updatedField.DataSourceId);
        if (dataSource == null)
          return Result<GetField>.Fail(
            new DomainError($"Invalid Data source id : {updatedField.DataSourceId}.")
          );
      }

      field = _mapper.Map(updatedField, field);

      field.DataSource = dataSource;

      _context.Fields.Update(field);
      await _context.SaveChangesAsync();

      return Result<GetField>.Ok(_mapper.Map<GetField>(field));
    }
  }
}