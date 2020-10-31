using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Model.Context
{
    public class ManagementAssistantContext : DbContext
    {
        public ManagementAssistantContext(DbContextOptions<ManagementAssistantContext> options) : base(options)
        {

        }

        //public DbSet<T> T { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
