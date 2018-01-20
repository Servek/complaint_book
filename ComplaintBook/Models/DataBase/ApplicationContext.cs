using System;
using Microsoft.EntityFrameworkCore;

namespace ComplaintBook.Models.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
    }
}
