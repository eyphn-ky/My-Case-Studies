using FarmasiDemo.Models.Concrete;
using FarmasiDemo.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmasiDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IEnumerable<ProductDto> GetAll()
        {
            var products =_productService.GetAll();
            return products;
        }

        [HttpPost("Add")]
        public void Add(ProductDto productDto)
        {
            _productService.Add(productDto);
        }
        [HttpPost("Delete")]
        public void Delete(ProductDto productDto)
        {
             _productService.Delete(productDto);
        }

    }
}
