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
    public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> builder)
        {
            builder.Property(t => t.Id).HasColumnName("id").IsRequired();
            builder.Property(t => t.CartId).HasColumnName("carrinho_id").IsRequired();
            builder.Property(t=> t.Status).HasColumnName("status").IsRequired();
            builder.Property(t => t.Tipo).HasColumnName("tipo").IsRequired();
            builder.Property(t => t.ValorTotal).HasColumnName("value_total").HasColumnType("decimal(5,2)").IsRequired();
            builder.Property(t => t.DeliveryId).HasColumnName("delivery_id"); 
    }
    }
}
