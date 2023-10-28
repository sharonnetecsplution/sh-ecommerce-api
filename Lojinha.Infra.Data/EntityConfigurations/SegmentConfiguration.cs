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
    public class SegmentConfiguration : IEntityTypeConfiguration<SegmentEntity>
    {
        public void Configure(EntityTypeBuilder<SegmentEntity> builder)
        {
            builder.Property(s => s.Id).HasColumnName("id").IsRequired();
            builder.Property(s => s.Name).HasColumnName("name").IsRequired();
        }
    }
}
