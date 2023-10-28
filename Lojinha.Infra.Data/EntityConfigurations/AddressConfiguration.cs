using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lojinha.Infra.Data.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public AddressConfiguration()
        {
        }

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AddressEntity> builder)
        {
            builder.Property(a => a.Id)
                .HasColumnName("id").IsRequired();
            builder.Property(a => a.Number).HasColumnName("number").IsRequired();
            builder.Property(a => a.Postal_code).HasColumnName("postal_code").IsRequired();
            builder.Property(a => a.District).HasColumnName("district").IsRequired();
            builder.Property(a => a.State).HasColumnName("state").IsRequired();
            builder.Property(a => a.County).HasColumnName("county").IsRequired();
            builder.Property(a => a.Street).HasColumnName("street").IsRequired();
            
        }
    }
}