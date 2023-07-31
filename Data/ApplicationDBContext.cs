using HRMSCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Data
{

  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Field> Fields { get; set; } = null!;
    public DbSet<DataSource> DataSources { get; set; } = null!;
  }
}