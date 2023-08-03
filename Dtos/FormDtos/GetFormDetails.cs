using HRMSCore.Dtos.ApprovalCycleDtos;
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

  public record GetFormDetails(
    int Id,
    string Name,
    List<GetFormStep> Steps,
    GetApprovalCycle? ApprovalCycle
  );
}