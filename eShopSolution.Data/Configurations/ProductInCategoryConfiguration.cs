using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(x => new {x.ProductId, x.CategoryId});
            builder.ToTable("ProductInCategories");
            builder.HasOne(t => t.Product).WithMany(pd => pd.ProductInCategories)
                .HasForeignKey(pd => pd.ProductId);
            builder.HasOne(t => t.Category).WithMany(pd => pd.ProductInCategories)
                .HasForeignKey(pd => pd.CategoryId);
        }
    }
}
