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
    public DbSet<User> Users { get; set; } = null!;


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


      // when form is deleted delete approval cycle 
      modelBuilder.Entity<ApprovalCycle>()
          .HasOne(ac => ac.Form)
          .WithOne(f => f.ApprovalCycle)
          .IsRequired(false)
          .OnDelete(DeleteBehavior.Cascade);

      // form may or may not have approval cycle
      // however approval cycle must have form

      modelBuilder.Entity<Form>()
          .HasOne(f => f.ApprovalCycle)
          .WithOne(ac => ac.Form)
          .HasForeignKey<ApprovalCycle>()
          .IsRequired(false);

      modelBuilder.Entity<ApprovalCycleStep>()
            .HasOne(acs => acs.Approver)
            .WithMany()
            .HasForeignKey(acs => acs.ApproverId)
            .IsRequired();

      modelBuilder.Entity<ApprovalCycle>()
            .HasMany(ac => ac.Steps)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

      base.OnModelCreating(modelBuilder);
    }
  }
}