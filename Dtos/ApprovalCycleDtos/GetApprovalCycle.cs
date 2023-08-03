using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRMSCore.Dtos.UserDtos;

namespace HRMSCore.Dtos.ApprovalCycleDtos
{
  public record GetApprovalCycleStep
  (
    [Required]
    GetUser Approver
  );

  public record GetApprovalCycle
  (
    [Required]
    [MinLength(1)]
    List<GetApprovalCycleStep> Steps
  );
}