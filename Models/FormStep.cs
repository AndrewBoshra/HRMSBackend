namespace HRMSCore.Models;

public class FormStep : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public int Order { get; set; } = 0;
  public List<FieldsRow> Rows { get; set; } = new List<FieldsRow>();


  public void UpdateLayout()
  {
    var order = 0;
    foreach (var row in Rows)
    {
      row.Order = order++;
      row.UpdateLayout();
    }
  }
}