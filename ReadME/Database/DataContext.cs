using Microsoft.EntityFrameworkCore;
using ReadME.Models;
namespace ReadME.Database
{
    public class DataContext:DbContext
    {
         public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<OTP> OTP { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Saved> Saved { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Notification> Notifications { get; set; }


        public DbSet<Admin> Admins { get; set; }
       

    }
}


//---- Migration commands ----

// dotnet ef migrations add anyname

// dotnet ef database update

// dotnet run

