using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<TopicsGroup> TopicsGroups { get; set; }

        public DbSet<UsersGroup> UsersGroups { get; set; }
    }
}
