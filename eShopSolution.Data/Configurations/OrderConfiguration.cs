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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Oders).HasForeignKey(x => x.UserId);
        }
    }
}
