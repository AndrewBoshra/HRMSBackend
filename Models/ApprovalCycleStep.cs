using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCore.Models
{
  public class ApprovalCycleStep : BaseEntity
  {
    public User Approver { get; private set; } = default!;
    public int ApproverId { get; } = 0;
    public int Order { get; set; }
  }
}