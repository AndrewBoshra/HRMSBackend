using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Models;

namespace HRMSCore.Dtos.FieldDtos
{
  public record GetField(
    int Id,
    string Name,
    FieldType Type = FieldType.Text,
    bool IsRequired = false,
    GetDataSource? DataSource = null
  );
}