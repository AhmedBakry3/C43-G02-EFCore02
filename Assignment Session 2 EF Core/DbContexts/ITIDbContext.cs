using Assignment_Session_1_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_Session_1_EF_Core.DbContexts
{
    internal class ITIDbContext : DbContext
    {
        #region Constructors
        public ITIDbContext() : base()
        { }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =. ; Database = ITI ; Trusted_Connection = true ;  TrustServerCertificate = true ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #endregion

        #region Properties
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }

        #endregion

    }
}
