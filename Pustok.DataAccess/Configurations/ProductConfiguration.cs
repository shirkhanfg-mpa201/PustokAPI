using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pustok.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x=> x.ImageUrl).IsRequired().HasMaxLength(1024);
            builder.Property(x=> x.Price).HasPrecision(10,2);
            builder.Property(x=> x.Description).IsRequired().HasMaxLength(4096);


            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
