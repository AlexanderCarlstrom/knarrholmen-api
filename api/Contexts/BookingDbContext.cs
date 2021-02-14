using api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Contexts
{
    public class BookingDbContext : IdentityDbContext<User>
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed db roles
            builder.Entity<IdentityRole>().HasData(new IdentityRole
                {Id = "037a87d5-2f44-474c-b494-295faeac310f", Name = "Admin", NormalizedName = "ADMIN".ToUpper()});
            builder.Entity<IdentityRole>().HasData(new IdentityRole
                {Id = "b8973d7c-483d-4a3e-9d1b-c04a4d809323", Name = "User", NormalizedName = "USER".ToUpper()});

            var hasher = new PasswordHasher<User>();

            const string email = "alexander@gmail.com";
            // Seed user
            builder.Entity<User>().HasData(
                new User
                {
                    Id = "8e3db864-4c10-41d8-8060-b4edb0534fac", FirstName = "Alexander", LastName = "Carlström",
                    Email = email, NormalizedEmail = email.ToUpper(), UserName = email,
                    NormalizedUserName = email.ToUpper(), EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Alexander1%")
                });

            // Seed relation between user and role
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "037a87d5-2f44-474c-b494-295faeac310f",
                    UserId = "8e3db864-4c10-41d8-8060-b4edb0534fac",
                });
        }
    }
}