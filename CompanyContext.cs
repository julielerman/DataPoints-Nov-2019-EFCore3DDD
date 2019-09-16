using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace EFCore3DDD

{
  public class CompanyContext : DbContext {
    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite ("Data Source=DP_Companies.db");

    }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
      modelBuilder.Entity<Company> ().HasKey ("CompanyId");
         modelBuilder.Entity<Company>().Property(c=>c.Name).HasField("_name");
      modelBuilder.Entity<Company> ().Property (c => c.OwnerName).HasField ("_ownerName");
      modelBuilder.Entity<Company> ().Property<string> ("_favoriteEmployee").HasField ("_favoriteEmployee");
      modelBuilder.Entity<Employee> ().OwnsOne (e => e.Name);
    }
    public override int SaveChanges () {
      foreach (var entry in ChangeTracker.Entries ()
          .Where (e => e.Metadata.IsOwned () && e.State == EntityState.Added)) {
        var ownership = entry.Metadata.FindOwnership ();
        var parentKey = ownership.Properties.Select (p => entry.Property (p.Name).CurrentValue).ToArray ();
        var parent = this.Find (ownership.PrincipalEntityType.ClrType, parentKey);
        if (parent != null) {
          var parentEntry = this.Entry (parent);
          if (parentEntry.State != EntityState.Added) {
            entry.State = EntityState.Modified;
          }
        }
      }
      return base.SaveChanges ();
    }
  }
}