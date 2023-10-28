using Lojinha.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.EntityConfigurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<SizeEntity>
    {
        public void Configure(EntityTypeBuilder<SizeEntity> builder)
        {
            builder.Property(c => c.Id).HasColumnName("id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").IsRequired();
        }
    }
}
