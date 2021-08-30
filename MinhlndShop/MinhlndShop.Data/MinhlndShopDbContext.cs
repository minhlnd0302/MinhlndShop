using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinhlndShop.Model.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MinhlndShop.Data
{
    public class MinhlndShopDbContext : DbContext
    {
        public MinhlndShopDbContext()
        {
        }
        public MinhlndShopDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //builder.Build();

                //SqlConnection con = new SqlConnection(builder.GetSection("Data").GetSection("ConnectionString").Value);
                //optionsBuilder.UseSqlServer(con);
                //IConfigurationRoot configuration = new ConfigurationBuilder()
                //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //    .AddJsonFile("appsettings.json")
                //    .Build();
                //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=MinhlndShop;Integrated Security=True");
            }
        }

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,4)");

                entity.HasKey(p => new { p.OrderID, p.ProductID });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,4)");

                entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18,4)");
            });

             

            modelBuilder.Entity<PostTag>()
            .HasKey(p => new { p.TagID, p.PostID });

            modelBuilder.Entity<ProductTag>()
            .HasKey(p => new { p.TagID, p.ProductID });
        }

    }
}
