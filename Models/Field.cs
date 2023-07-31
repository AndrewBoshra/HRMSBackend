namespace HRMSCore.Models
{
  public class Field : BaseEntity
  {
    public string Name { get; set; } = string.Empty;

    public FieldType Type { get; set; } = FieldType.Text;

    public bool IsRequired { get; set; } = false;

    public DataSource? DataSource { get; set; }
  }
}