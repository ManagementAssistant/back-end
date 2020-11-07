using BHA.ManagementAssistant.Nutritious.Common.Constant;
using BHA.ManagementAssistant.Nutritious.Core.Base.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace BHA.ManagementAssistant.Nutritious.Model.Context
{
    public class ManagementAssistantContext : DbContext
    {
        public ManagementAssistantContext(DbContextOptions<ManagementAssistantContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(Connection.LocalConnectionString);
    }
}
