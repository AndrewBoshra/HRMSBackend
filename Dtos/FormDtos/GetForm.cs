using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRMSCore.Dtos.FieldDtos;

namespace HRMSCore.Dtos.FormDtos
{
  public record GetFormField(
    GetField Field
  );
  public record GetFieldsRow(
    List<GetFormField> Fields
  );

  public record GetFormStep(
    string Name,
    List<GetFieldsRow> Rows
  );

  public record GetForm(
    int Id,
    string Name,
    List<GetFormStep> Steps
  );
}