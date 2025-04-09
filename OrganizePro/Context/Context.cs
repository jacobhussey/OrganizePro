using OrganizePro.Models;
using Microsoft.EntityFrameworkCore;

namespace OrganizePro.Context;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.IsSubclassOf(typeof(EntityBase)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreateDate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                modelBuilder.Entity(entityType.ClrType)
                    .Property("LastUpdate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            }
        }

        modelBuilder.Entity<Address>()
            .Property(a => a.Id)
            .HasColumnName("addressId");

        modelBuilder.Entity<Appointment>()
            .Property(a => a.Id)
            .HasColumnName("appointmentId");

        modelBuilder.Entity<City>()
            .Property(c => c.Id)
            .HasColumnName("cityId");

        modelBuilder.Entity<Country>()
            .Property(c => c.Id)
            .HasColumnName("countryId");

        modelBuilder.Entity<Customer>()
            .Property(c => c.Id)
            .HasColumnName("customerId");

        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .HasColumnName("userId");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is EntityBase && e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            var entity = (EntityBase)entry.Entity;
            entity.LastUpdate = DateTime.UtcNow;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}
