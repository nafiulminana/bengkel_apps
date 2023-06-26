using BengkelMotorApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BengkelMotorApp.Areas.Identity.Data;

public class ApplicationContext : IdentityDbContext<UserIdentity>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<SparePart> SpareParts { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionDetail> TransactionDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<UserIdentity>(
            entity =>
            {
                entity.ToTable(name: "tb_users");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address);
            });
        builder.Entity<IdentityRole>(
            entity =>
            {
                entity.ToTable(name: "tb_roles");
            });
        builder.Entity<IdentityUserRole<string>>(
            entity =>
            {
                entity.ToTable("tb_user_roles");
            });
        builder.Entity<IdentityUserClaim<string>>(
            entity =>
            {
                entity.ToTable("tb_user_claims");
            });
        builder.Entity<IdentityUserLogin<string>>(
            entity =>
            {
                entity.ToTable("tb_user_logins");
            });
        builder.Entity<IdentityRoleClaim<string>>(
            entity =>
            {
                entity.ToTable("tb_role_claims");
            });
        builder.Entity<IdentityUserToken<string>>(
            entity =>
            {
                entity.ToTable("tb_user_tokens");
            });

        builder.Entity<SparePart>(
            entity =>
            {
                entity.ToTable(name: "tb_sparepart");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

        builder.Entity<ServiceType>(
            entity =>
            {
                entity.ToTable(name: "tb_servicetype");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

        builder.Entity<Transaction>(
            entity =>
            {
                entity.ToTable(name: "tb_transaction");
            });

        builder.Entity<TransactionDetail>(
            entity =>
            {
                entity.ToTable(name: "tb_transactiondetail");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });
    }
}
