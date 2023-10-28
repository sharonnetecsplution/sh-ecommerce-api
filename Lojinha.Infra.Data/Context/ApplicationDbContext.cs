using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CartItemEntity> CarItens { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<Category_productEntity> Categories_products { get; set; }
        public DbSet<ColorEntity> Colores { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<AccessoryEntity> Accessories { get; set; }
        public DbSet<ShoesEntity> Shoes { get; set; }
        public DbSet<ClothingEntity> Clothings { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<StoreEntity> Stores { get; set; }
        public DbSet<DeliveryEntity> Deliveries { get; set; }
        public DbSet<SegmentEntity> Segments { get; set; }
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<FeatureStockEntity> Features_stocks { get; set; }
        public DbSet<ImageEntity> Images { get; set; }

      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new CartItemConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new Category_productConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new StockConfiguration());
            builder.ApplyConfiguration(new DeliveryConfiguration());
            builder.ApplyConfiguration(new SegmentConfiguration());
            builder.ApplyConfiguration(new SizeConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            builder.ApplyConfiguration(new ImageProductConfiguration());

        }
    }
}
