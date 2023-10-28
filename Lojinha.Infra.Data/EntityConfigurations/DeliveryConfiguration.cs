using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lojinha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Infra.Data.EntityConfigurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<DeliveryEntity>
    {

        public void Configure(EntityTypeBuilder<DeliveryEntity> builder)
        {
            builder.Property(d => d.Id)
                .HasColumnName("id").IsRequired();
            builder.Property(d => d.Tipo)
                .HasColumnName("name").IsRequired();
            builder.Property(d => d.Price)
                .HasColumnName("price").HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(d => d.DeliveryTime)
                .HasColumnName("delivery_time").IsRequired();
        }
    }
}
