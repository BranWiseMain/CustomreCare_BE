using Branwise.Domains.Entites;
using Branwise.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace Branwise.Services;

public class CustomCareDbContext : DbContext
{
    public CustomCareDbContext(DbContextOptions<CustomCareDbContext> options) : base(options) { }

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<FeedBack> FeedBacks { get; set; }
    public DbSet<IssueReport> IssueReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Admin
        modelBuilder.Entity<Admin>().ToTable("Admins");
        modelBuilder.Entity<Admin>().HasKey(a => a.Id);
        modelBuilder.Entity<Admin>().Property(a => a.FirstName).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.LastName).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.Email).HasMaxLength(256).IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.PhoneNumber).HasMaxLength(15).IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.HashedPassword).HasMaxLength(256).IsRequired();

        // Client
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<Client>().HasKey(c => c.Id);
        modelBuilder.Entity<Client>().Property(c => c.Name).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Client>().Property(c => c.ApiKeyHash).HasMaxLength(256).IsRequired();
        modelBuilder.Entity<Client>().Property(c => c.AllowedIPs).HasMaxLength(512);

        // IssueReport
        modelBuilder.Entity<IssueReport>().ToTable("IssueReports");
        modelBuilder.Entity<IssueReport>().HasKey(ir => ir.Id);
        modelBuilder.Entity<IssueReport>().Property(ir => ir.CustomerNumber).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<IssueReport>().Property(ir => ir.Description).HasMaxLength(1000);
        modelBuilder.Entity<IssueReport>().Property(ir => ir.IssueType).IsRequired();
        modelBuilder.Entity<IssueReport>().Property(ir => ir.Status).IsRequired();

        modelBuilder.Entity<IssueReport>()
            .HasOne(ir => ir.Client)
            .WithMany(c => c.IssueReports)
            .HasForeignKey(ir => ir.TenantId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // FeedBack
        modelBuilder.Entity<FeedBack>().ToTable("FeedBacks");
        modelBuilder.Entity<FeedBack>().HasKey(fb => fb.Id);
        modelBuilder.Entity<FeedBack>().Property(fb => fb.CustomerNumber).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<FeedBack>().Property(fb => fb.Message).HasMaxLength(1000).IsRequired();
        modelBuilder.Entity<FeedBack>().Property(fb => fb.Rating).IsRequired();

        modelBuilder.Entity<FeedBack>()
            .HasOne(fb => fb.Client)
            .WithMany(c => c.FeedBacks)
            .HasForeignKey(fb => fb.TenantId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
