using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using HRMSCore.Dtos.ApprovalCycleDtos;

namespace HRMSCore.Dtos.FormDtos
{
  public record AddFormField(
    int FieldId
  );

  public record AddFieldsRow(
    [MinLength(1)]
    List<AddFormField> Fields
  );

  public record AddFormStep(
    [Required]
    string Name,
    [MinLength(1)]
    List<AddFieldsRow> Rows
  );

  public record AddForm(
    [Required]
    string Name,
    [MinLength(1)]
    List<AddFormStep> Steps,

    [Optional]
    AddApprovalCycle? ApprovalCycle
  );
}