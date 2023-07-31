using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HRMSCore.Models;

namespace HRMSCore.Dtos.FieldDtos
{
  public record AddField(
    [Required]
    string Name,
    [EnumDataType(typeof(FieldType))]
    FieldType FieldType,
    bool IsRequired = false,
    int? DataSourceId = null
  );
}