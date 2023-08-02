namespace HRMSCore.Models;

public class Form : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public List<FormStep> Steps { get; set; } = new List<FormStep>();
  public ApprovalCycle? ApprovalCycle { get; set; }


  public void UpdateLayout()
  {
    var order = 0;
    foreach (var step in Steps)
    {
      step.Order = order++;
      step.UpdateLayout();
    }
  }
}