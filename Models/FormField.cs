namespace HRMSCore.Models;

public class FormField : BaseEntity
{
  public int Order { get; set; } = 0;
  public required Field Field { get; set; }
  public int FieldId { get; set; }
}