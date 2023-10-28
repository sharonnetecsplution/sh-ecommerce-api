using Lojinha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.EntityConfigurations
{
    internal class Category_productConfiguration : IEntityTypeConfiguration<Category_productEntity>
    {
        void IEntityTypeConfiguration<Category_productEntity>.Configure(EntityTypeBuilder<Category_productEntity> builder)
        {
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.CategoryId).HasColumnName("categoria_id").IsRequired();
            builder.Property(p => p.ProductId).HasColumnName("produto_id").IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(c => c.CategoryId);

            builder.HasOne(c => c.Product)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.ProductId);

        }
    }
}
