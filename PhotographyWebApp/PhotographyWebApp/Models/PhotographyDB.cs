namespace PhotographyWebApp.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PhotographyWebApp.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyDB : IdentityDbContext<ApplicationUser>
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PhotographyWebApp.Models.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public PhotographyDB()
            : base("name=constr")
        {
        }

        public static PhotographyDB Create()
        {
            return new PhotographyDB();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<OurWork> OurWorks { get; set; }
        public virtual DbSet<OurClient> OurClients { get; set; }
        public virtual DbSet<DropDown_Service> DropDown_Services { get; set; }
        public virtual DbSet<DropDown_Branch> DropDown_Branchs { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}