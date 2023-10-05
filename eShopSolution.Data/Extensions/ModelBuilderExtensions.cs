using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { key = "HomeTitle", value = "This is home page of eShopSolution" },
                new AppConfig() { key = "HomeKeyword", value = "This is keyword of eShopSolution" },
                new AppConfig() { key = "HomeDescription", value = "This is description of eShopSolution" }
                );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "Tiếng Anh", IsDefault = false }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHom = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHom = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active,
                });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                        new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo Nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang Nam", SeoTitle = "Sán phẩm thời trang nam" },
                        new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men" },
                        new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo Nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang Nữ", SeoTitle = "Sán phẩm thời trang nữ" },
                        new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt product for women", SeoTitle = "The shirt product for woman" }

                );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 10000,
                    Price = 20000,
                    Stock = 0,
                    ViewCount = 0,
                });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo sơ mi trắng Việt Nam",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-so-mi-trang-viet-nam",
                     SeoDescription = "Áo sơ mi trắng Tiến Việt",
                     SeoTitle = "Áo sơ mi trắng Tiến Việt",
                     Description = "Áo sơ mi trắng Tiến Việt ",
                     Details = "Áo sơ mi trắng Tiến Việt"
                 },
                  new ProductTranslation()
                  {
                      Id = 2,
                      ProductId = 1,
                      Name = "Ao so mi Make in VietNam",
                      LanguageId = "en-US",
                      SeoAlias = "Ao so mi trang Tien Viet",
                      SeoDescription = "Ao so mi trang Tien Viet",
                      SeoTitle = "Ao so mi trang Tien Viet",
                      Description = "Ao so mi trang Tien Viet",
                      Details = "Ao so mi trang Tien Viet"
                  });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );
        }
    }
}
