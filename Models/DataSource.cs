using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSCore.Models
{
  public class DataSource : BaseEntity
  {
    public string Name { get; set; } = string.Empty;

    public List<string> Options { get; set; } = new List<string>();
  }
}