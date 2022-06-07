using DomainClass.UserExam;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SqlServer.Common
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            modelBuilder.Entity<UserExam>().HasQueryFilter(c => c.IsDeleted == false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
