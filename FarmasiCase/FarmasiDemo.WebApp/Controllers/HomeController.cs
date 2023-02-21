using FarmasiDemo.Models.Concrete.CacheDto;
using FarmasiDemo.Models.Helper.CacheHelper;
using FarmasiDemo.Services.Interface;
using FarmasiDemo.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmasiDemo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICacheHelper _cacheHelper;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICacheHelper cacheHelper)
        {
            _cacheHelper = cacheHelper;
            _productService=productService;
            _logger = logger;
        }

        public IActionResult Products()
        {
            return View(_productService.GetAll().ToList());
        }
        public IActionResult AddCartAjaxPop(string productId)
        {
            var cache = _cacheHelper.GetAsync("Basket");
            var product=_productService.GetSingle(productId);
            List<BasketDto> basketDto = new List<BasketDto>();
            if (cache == null)
            {
                basketDto.Add(new BasketDto { Product = product, Quantity = 1 });
            }
            else
            {
                basketDto=JsonConvert.DeserializeObject<List<BasketDto>>(cache);
                if(basketDto.Any(x => x.Product.Id == productId))
                {
                    basketDto.FirstOrDefault(x => x.Product.Id == productId).Quantity+=1;
                }
                else
                {
                    basketDto.Add(new BasketDto {Product=product,Quantity=1});
                }
                _cacheHelper.Remove("Basket");
            }
            _cacheHelper.SetAsync("Basket", JsonConvert.SerializeObject(basketDto));
            return Json(new { success = true, data = basketDto });

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
