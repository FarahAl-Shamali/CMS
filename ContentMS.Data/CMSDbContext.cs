using ContentMS.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContentMS.Data
{
    public class CMSDbContext(DbContextOptions<CMSDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAttachment> PostAttachments { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<ContentChangeLog> ContentChangeLogs { get; set; }
    }
}
