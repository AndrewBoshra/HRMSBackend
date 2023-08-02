using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCore.Models
{
  public class ApprovalCycle : BaseEntity
  {
    public List<ApprovalCycleStep> Steps { get; set; } = new List<ApprovalCycleStep>();
    public Form Form { get; set; } = null!;
  }
}