using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace BHA.ManagementAssistant.Nutritious.Model.Context
{
    public class ManagementAssistantContext : DbContext
    {
        public ManagementAssistantContext(DbContextOptions<ManagementAssistantContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<MenuElement> MenuElement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<Organization>(h => h.Organization)
                .WithMany(w => w.User)
                .HasForeignKey(fk => fk.OrganizationID);

            modelBuilder.Entity<Company>()
                .HasOne<User>(c => c.User)
                .WithMany(w => w.Company)
                .HasForeignKey(fk => fk.CreatedByUserID);

            modelBuilder.Entity<MenuElement>()
                .HasOne<MenuElement>(h => h.OwnerMenuElement)
                .WithMany(w => w.TenantMenuElement)
                .HasForeignKey(fk => fk.MenuElementID);

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(Connection.LocalConnectionString);
    }
}
