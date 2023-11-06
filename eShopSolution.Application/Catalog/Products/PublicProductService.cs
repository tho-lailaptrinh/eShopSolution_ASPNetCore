using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.ProductImages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {

        private readonly EShopDbContext _context;
        public PublicProductService(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<PageResult<ProductViewModel>> GetAllByCategoryId(string language,GetPublicProductPagingRequest request)
        {
            // Select Join 
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join pich in _context.Categories on pic.CategoryId equals pich.Id
                        where pt.LanguageId == language
                        select new { p, pt, pic };
            // 2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(x => x.pic.CategoryId == request.CategoryId); // chỉ lấy các sản phẩm thuộc trong danh sách ID nằm trong CategoryIds 
            }
            int tatolRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize) // Skip : bỏ qua các bản ghi của trang trước đó
                .Take(request.PageSize)                                       // Take : Xác định số bản ghi trên trang hiện tại   
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                }).ToList();
            var pageResult = new PageResult<ProductViewModel>() // đối tượng trả về
            {
                TotalRecord = tatolRow, // TotalRecord chứa tổng số bản ghi
                Items = data   // Items : danh sách sản phẩm trong trang hiện tại
            };
            return pageResult;
        }


    }
}
