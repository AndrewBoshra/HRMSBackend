using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HRMSCore.Dtos.FormDtos
{
  public record AddFormField(
    int FieldId
  );

  public record AddFieldsRow(
    List<AddFormField> Fields
  );

  public record AddFormStep(
    [Required]
    string Name,
    List<AddFieldsRow> Rows
  );

  public record AddForm(
    [Required]
    string Name,
    List<AddFormStep> Steps
  );
}