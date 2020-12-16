namespace ASP_Identity_Inegrated_DB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class echodb : IdentityDbContext<ApplicationUser>
    {
        public echodb()
            : base("name=constr")
        {
        }

        public static echodb Create()
        {
            return new echodb();
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Create for identity tables

            // Rename orginal table in aspidentity to other names
            //modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo");
            //modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo");
            //modelBuilder.Entity<IdentityUserRole>().ToTable("UsersRoles", "dbo");
            //modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims", "dbo");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins", "dbo");

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
