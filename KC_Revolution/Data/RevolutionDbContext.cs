using KC_Revolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KC_Revolution.Data
{
    public class RevolutionDbContext : DbContext
    {
        public RevolutionDbContext(DbContextOptions<RevolutionDbContext> options)
            : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Sermon> Sermons { get; set; }
        public DbSet<SmallGroup> SmallGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BlogPost>().ToTable("BlogPost");
            builder.Entity<Event>().ToTable("Event");
            builder.Entity<Sermon>().ToTable("Sermon");
            builder.Entity<SmallGroup>().ToTable("SmallGroup");
        }
    }
}
