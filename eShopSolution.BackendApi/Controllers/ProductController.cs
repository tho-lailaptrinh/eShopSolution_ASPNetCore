using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.ProductImages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService; 
        }
       
        // http://localhost:post/product?/pageIndex=1&pageSize=10&categoryId=1 
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId,[FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(languageId,request);
            return Ok(products);
        }

        // http://localhost:post/product/1
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId);
            if (product == null) return BadRequest("cannot find product ");
            return Ok(product);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageProductService.Create(request);
            if(productId == 0)
            {
                return BadRequest();
            }
            var product = await _manageProductService.GetById(productId, request.LanguageId); 
            return   CreatedAtAction(nameof(GetById), new {id = productId}, product);
        }

        // hpptput là update nhiều phần
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _manageProductService.Delete(id);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        //HttpPatch là update một phần
        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId,decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(productId,newPrice);
            if (isSuccessful)
            {
                return Ok();
            }
            return BadRequest();
        }
        // Image
        [HttpPost("{productId}/Image")]
        public async Task<IActionResult> CreateImage(int productId,[FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _manageProductService.AddImage(productId,request);
            if (imageId == 0)
            {
                return BadRequest();
            }
            var productImage = await _manageProductService.GetImageById(imageId);
            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, productImage );
        }

        // Update Image
        [HttpPut("{productId}/image/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId,[FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageUpdate = await _manageProductService.UpdateImage(imageId,request);
            if (imageUpdate == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        // Delete Image
        [HttpDelete("{productId}/image/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageUpdate = await _manageProductService.RemoveImage(imageId);
            if (imageUpdate == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        // get by id
        [HttpGet("{productId}/image/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId   )
        {
            var product = await _manageProductService.GetImageById(imageId);
            if (product == null) return BadRequest("cannot find product ");
            return Ok(product);
        }

    }
}
