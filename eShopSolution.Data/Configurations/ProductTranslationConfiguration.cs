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
    public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
    {
        public void Configure(EntityTypeBuilder<ProductTranslation> builder)
        {
            builder.ToTable("ProductTranslations");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SeoTitle).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Details).HasMaxLength(455);
            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(10);
            builder.HasOne(f => f.Language).WithMany(f => f.ProductTranslations).HasForeignKey(f => f.LanguageId);
            builder.HasOne(f => f.Product).WithMany(f => f.ProductTranslations).HasForeignKey(f => f.ProductId);

        }
    }
}
