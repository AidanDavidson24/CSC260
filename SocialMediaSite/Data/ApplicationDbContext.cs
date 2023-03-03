using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaSite.Migrations;
using SocialMediaSite.Models;

namespace SocialMediaSite.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public DbSet<Images> Images { get; set; }
        public DbSet<MyPage> MyPage { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}