using Branwise.Domains.Entites;
using Microsoft.EntityFrameworkCore;

namespace Branwise.Services;

public class CustomCareDbContext : DbContext
{
    public CustomCareDbContext(DbContextOptions<CustomCareDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<FeedBack> FeedBacks { get; set; }
    public DbSet<IssueReport> IssueReports { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<Supervisor> Supervisors { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Admin>().ToTable("Admins");
        modelBuilder.Entity<FeedBack>().ToTable("FeedBacks");
        modelBuilder.Entity<IssueReport>().ToTable("IssueReports");
        modelBuilder.Entity<Provider>().ToTable("Providers");
        modelBuilder.Entity<Supervisor>().ToTable("Supervisors");

        // Configure primary keys
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().Property(u => u.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.LastName)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.Email)
            .HasMaxLength(256)
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.HashedPassword)
            .HasMaxLength(256)
            .IsRequired();
        modelBuilder.Entity<User>().Property(u => u.ProviderId)
            .IsRequired();

        modelBuilder.Entity<Admin>().HasKey(a => a.Id);
        modelBuilder.Entity<Admin>().Property(a => a.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.LastName)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.Email)
            .HasMaxLength(256)
            .IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired();
        modelBuilder.Entity<Admin>().Property(a => a.HashedPassword)
            .HasMaxLength(256)
            .IsRequired();

        modelBuilder.Entity<Supervisor>().HasKey(s => s.Id);
        modelBuilder.Entity<Supervisor>().Property(s => s.FirstName)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Supervisor>().Property(s => s.LastName)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Supervisor>().Property(s => s.Email)
            .HasMaxLength(256)
            .IsRequired();
        modelBuilder.Entity<Supervisor>().Property(s => s.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired();
        modelBuilder.Entity<Supervisor>().Property(s => s.HashedPassword)
            .HasMaxLength(256)
            .IsRequired();

        modelBuilder.Entity<IssueReport>().HasKey(ir => ir.Id);
        modelBuilder.Entity<IssueReport>().Property(ir => ir.Description)
            .HasMaxLength(1000)
            .IsRequired();
        modelBuilder.Entity<IssueReport>().Property(ir => ir.UserId)
            .IsRequired();
        modelBuilder.Entity<IssueReport>().Property(ir => ir.ProviderId)
            .IsRequired();
        modelBuilder.Entity<IssueReport>().Property(ir => ir.problemType)
            .IsRequired();
        modelBuilder.Entity<IssueReport>().Property(ir => ir.IStatus)
            .IsRequired();

        modelBuilder.Entity<FeedBack>().HasKey(f => f.Id);
        modelBuilder.Entity<FeedBack>().Property(f => f.Message)
            .HasMaxLength(1000)
            .IsRequired();
        modelBuilder.Entity<FeedBack>().Property(f => f.UserId)
            .IsRequired();
        modelBuilder.Entity<FeedBack>().Property(f => f.Sender)
            .IsRequired();

        modelBuilder.Entity<Provider>().HasKey(p => p.Id);
        modelBuilder.Entity<Provider>().Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Provider>().Property(p => p.LogoUrl)
            .HasMaxLength(512);

        //relationships 

        modelBuilder.Entity<Provider>()
                .HasMany(p => p.User)
                .WithOne(u => u.Provider)
                .HasForeignKey(u => u.ProviderId);

        modelBuilder.Entity<IssueReport>()
               .HasOne(i => i.User)
               .WithMany(u => u.IssueReports)
               .HasForeignKey(i => i.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<IssueReport>()
              .HasOne(i => i.Provider)
              .WithMany(p => p.IssueReports)
              .HasForeignKey(i => i.ProviderId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<FeedBack>()
             .HasOne(f => f.User)
             .WithMany(u => u.Feedbacks)
             .HasForeignKey(f => f.UserId)
             .IsRequired();
    }

}
