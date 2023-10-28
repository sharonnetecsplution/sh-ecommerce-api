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
    public class ImageProductConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.Property(i => i.Id)
                .HasColumnName("id").IsRequired();
            builder.Property(i => i.Name)
                .HasColumnName("name").IsRequired();
            builder.Property(i => i.endpoint);

        }
    }
}
