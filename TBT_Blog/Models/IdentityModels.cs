using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace TBT_Blog.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BlogConnnectionDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogConnnectionDbContext()
            : base("BlogConnnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Commenter> Commenters { get; set; }

        public DbSet<AuthorLikedPost> AuthorLikedPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<WebsiteExceptions> WebsiteExceptions { get; set; }
        public DbSet<OS> OSs { get; set; }

        public static BlogConnnectionDbContext Create()
        {
            return new BlogConnnectionDbContext();
        }
    }
}