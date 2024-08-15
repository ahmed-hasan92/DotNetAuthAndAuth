using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnnlineStore.Data
{
    public class OnlineStoreAuthDbContext : IdentityDbContext<IdentityUser>
    {
        public OnlineStoreAuthDbContext(DbContextOptions<OnlineStoreAuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "a71aa5a8-7699-4f49-944b-b5281ac3954c";
            var userRoleId = "5d084de9-408f-4ded-9396-8c8eaedbb0de";

            var roles = new List<IdentityRole>()
            {

                new IdentityRole() {
                
                    Id= adminRoleId,
                    ConcurrencyStamp=adminRoleId,
                    Name="admin",
                    NormalizedName="admin".ToUpper()
                
                
                },


                new IdentityRole() {

                    Id= userRoleId,
                    ConcurrencyStamp=userRoleId,
                    Name="user",
                    NormalizedName="user".ToUpper()


                }

        };
            builder.Entity<IdentityRole>().HasData(roles);
    }
    }
}