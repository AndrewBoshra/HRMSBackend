using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCore.Dtos.DataSourceDtos
{
  public record AddDataSource(
    [Required]
    string Name,
    [MinLength(1)]
    List<string> Options
  );
}