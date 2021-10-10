using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class ForumDbContext : IdentityDbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<TopicsGroup> TopicsGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { 
                                    Id = "2299b2e1-cb84-47ca-a51f-928a49233417", 
                                    Name = "Administrator", 
                                    NormalizedName = "ADMINISTRATOR".ToUpper() });

            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
                                {
                                       new IdentityRole
                                       {
                                           Id = Guid.NewGuid().ToString(),
                                           Name = "Moderator",
                                           NormalizedName = "MODERATOR".ToUpper()
                                       },
                                       new IdentityRole
                                       {
                                           Id = Guid.NewGuid().ToString(),
                                           Name = "User",
                                           NormalizedName = "USER".ToUpper()
                                       }
                                });


            var hasher = new PasswordHasher<IdentityUser>();


            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "e30dcf0c-373f-474f-9957-6ca8ca79cdc0",
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@farhad.su",
                    NormalizedEmail = "ADMIN@FARHAD.SU",
                    PasswordHash = hasher.HashPassword(null, "Pa$$W0rd!")
                }
            );


            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2299b2e1-cb84-47ca-a51f-928a49233417",
                    UserId = "e30dcf0c-373f-474f-9957-6ca8ca79cdc0"
                }
            );
        }
    }
}
