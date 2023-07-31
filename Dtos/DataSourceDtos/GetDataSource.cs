namespace HRMSCore.Dtos.DataSourceDtos
{
  public record GetDataSource(
    int Id,
    string Name,
    List<string> Options
  );
}