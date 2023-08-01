namespace HRMSCore.Models;

public class FieldsRow : BaseEntity
{
  public List<FormField> Fields { get; set; } = new List<FormField>();
  public int Order { get; set; } = 0;


  public void UpdateLayout()
  {
    var order = 0;
    foreach (var field in Fields)
    {
      field.Order = order++;
    }
  }
}