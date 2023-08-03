using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCore.Dtos.ApprovalCycleDtos
{
  public record AddApprovalCycleStep
  (
    [Required]
    int ApproverId
  );

  public record AddApprovalCycle
  (
    [Required]
    [MinLength(1)]
    List<AddApprovalCycleStep> Steps
  );
}