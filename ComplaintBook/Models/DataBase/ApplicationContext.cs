using System;
using Microsoft.EntityFrameworkCore;

namespace ComplaintBook.Models.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Grade> Grades { get; set; }

        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}
