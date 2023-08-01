using HRMSCore.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Data
{

  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Form> Forms { get; set; } = null!;
    public DbSet<Field> Fields { get; set; } = null!;
    public DbSet<DataSource> DataSources { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<FormField>()
            .HasOne(ff => ff.Field)
            .WithMany()
            .HasForeignKey(ff => ff.FieldId)
            .IsRequired();

      // on form delete delete all the steps 
      modelBuilder.Entity<Form>()
            .HasMany(f => f.Steps)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

      // on step delete delete all the rows
      modelBuilder.Entity<FormStep>()
            .HasMany(fs => fs.Rows)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

      // on row delete delete all the fields
      modelBuilder.Entity<FieldsRow>()
            .HasMany(fr => fr.Fields)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);


      base.OnModelCreating(modelBuilder);
    }
  }
}