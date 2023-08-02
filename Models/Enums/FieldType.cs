
using System.Text.Json.Serialization;

namespace HRMSCore.Models
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum FieldType
  {
    Text,
    Number,
    Date,
    Select,
    MultiSelect
  }
}