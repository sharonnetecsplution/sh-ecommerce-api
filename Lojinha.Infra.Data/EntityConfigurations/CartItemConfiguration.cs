using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Infra.Data.EntityConfigurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItemEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("id").IsRequired();
            builder.Property(c => c.StockId).HasColumnName("estoque_id").IsRequired();
            builder.Property(c => c.CarId).HasColumnName("carrinho_id").IsRequired();
            builder.Property(c => c.Amount).HasColumnName("amount").IsRequired();
            
        }
    }
}