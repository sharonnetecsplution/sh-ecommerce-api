using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Infra.Data.EntityConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<CartEntity>
    {
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("id").IsRequired();
            builder.Property(c => c.Amount).HasColumnName("amount").IsRequired();
            builder.Property(c => c.Value_Total).HasColumnType("decimal(5,2)").HasColumnName("value_total").IsRequired();
            builder.HasMany(c => c.Itens)
                .WithOne(c => c.Car)
                .HasForeignKey(c => c.CarId);
        }
    }
}