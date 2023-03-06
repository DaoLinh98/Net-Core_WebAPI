using Microsoft.EntityFrameworkCore;
using NetCore_API.Entity;

namespace NetCore_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options)
        {
        }
        public DataContext() : base()
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.ToTable("Accounts");
                e.HasKey(a => a.Id);
                e.HasIndex(p => p.Email)
               .IsUnique(true);

            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(a => a.User_Id);

                e.HasOne(e => e.Department)
               .WithMany(e => e.Users)
               .HasForeignKey(e => e.Depart_Id);

            });

            modelBuilder.Entity<Asset>(e =>
            {
                e.ToTable("Assets");
                e.HasKey(a => a.Asset_Id);

            });
            modelBuilder.Entity<Assignment>(e =>
            {
                e.ToTable("Assugnments");
                e.HasKey(e => new { e.User_Id, e.Asset_Id });

                e.HasOne(e => e.Asset)
                .WithMany(e => e.Assignments)
                .HasForeignKey(e => e.Asset_Id);


                e.HasOne(e => e.User)
                .WithMany(e => e.Assignments)
                .HasForeignKey(e => e.User_Id);

            });


        }


    }
}
