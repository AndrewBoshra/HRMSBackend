using System.Text.Json.Serialization;

namespace HRMSCore.Models
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum UserRole
  {
    Employee,
    Manager,
    Admin
  }
}