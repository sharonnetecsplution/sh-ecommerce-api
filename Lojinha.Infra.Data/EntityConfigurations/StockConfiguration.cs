using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.EntityConfigurations
{
    public class StockConfiguration : IEntityTypeConfiguration<StockEntity>
    {
        public void Configure(EntityTypeBuilder<StockEntity> builder)
        {
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.AmountTotal).HasColumnName("amount");
            builder.Property(s => s.StoreId).HasColumnName("storeId");

            builder.Property(s => s.ProductId).HasColumnName("productId");



        }


    }
}
