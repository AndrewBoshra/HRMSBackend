using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Errors;
using HRMS.Data;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Errors;
using HRMSCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMSCore.Services.DataSourceService
{
  public class DataSourceService : IDataSourceService
  {
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public DataSourceService(IMapper mapper, ApplicationDbContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task<Result<GetDataSource>> AddDataSource(AddDataSource newDataSource)
    {
      if (await _context.DataSources.AnyAsync(x => x.Name == newDataSource.Name))
        return Result<GetDataSource>.Fail(
          new DomainError($"Data source with name {newDataSource.Name} already exists.")
        );


      DataSource dataSource = _mapper.Map<DataSource>(newDataSource);

      _context.DataSources.Add(dataSource);
      await _context.SaveChangesAsync();

      return Result<GetDataSource>.Ok(_mapper.Map<GetDataSource>(dataSource));

    }

    public async Task<Result<int>> DeleteDataSource(int id)
    {
      int deletedRows = await _context.DataSources.Where(
        x => x.Id == id
      ).ExecuteDeleteAsync();

      if (deletedRows == 0)
      {
        return Result<int>.Fail(
          new EntityNotFoundError($"Data source with id {id} not found.")
        );
      }

      return Result<int>.Ok(id);
    }

    public async Task<Result<List<GetDataSource>>> GetAllDataSources()
    {
      var dataSources = _mapper.Map<List<GetDataSource>>(await _context.DataSources.ToListAsync());
      return Result<List<GetDataSource>>.Ok(dataSources);
    }

    public async Task<Result<GetDataSource>> GetDataSourceById(int id)
    {

      var dataSource = await _context.DataSources.FirstOrDefaultAsync(x => x.Id == id);
      if (dataSource == null)
        return Result<GetDataSource>.Fail(
          new EntityNotFoundError($"Data source with id {id} not found.")
        );

      return Result<GetDataSource>.Ok(_mapper.Map<GetDataSource>(dataSource));
    }

    public async Task<Result<GetDataSource>> UpdateDataSource(int id, UpdateDataSource updateDataSource)
    {
      var oldDataSource = await _context.DataSources.FirstOrDefaultAsync(x => x.Id == id);
      if (oldDataSource == null)
        return Result<GetDataSource>.Fail(
          new EntityNotFoundError($"Data source with id {id} not found.")
        );

      if (await _context.DataSources.AnyAsync(x => x.Name == updateDataSource.Name && x.Id != id))
        return Result<GetDataSource>.Fail(
          new DomainError($"Data source with name {updateDataSource.Name} already exists.")
        );

      var updatedDataSource = _mapper.Map<UpdateDataSource, DataSource>(updateDataSource, oldDataSource);

      _context.DataSources.Update(updatedDataSource);
      await _context.SaveChangesAsync();

      return Result<GetDataSource>.Ok(_mapper.Map<GetDataSource>(updatedDataSource));
    }
  }
}