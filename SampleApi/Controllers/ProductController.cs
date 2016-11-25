using SampleApi.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleApi.Controllers
{
    [RoutePrefix("api")]
    public class ProductController : BaseApiController
    {

        [HttpGet]
        [Authorize]
        [Route("products")]
        public Task<HttpResponseMessage> Get()
        {
            var products = new List<Product>
            {
                new Product {Description="Iphone 6",Price = 3000m },
                new Product {Description="Smart Tv Sansung",Price = 2800m },
                new Product {Description="Notebook Dell",Price = 4300m },
                new Product {Description="mouse optico",Price = 41m },
                new Product {Description="Windows 10",Price = 200m },
                new Product {Description="Smartphone Moto Z",Price = 3800m },
                new Product {Description="Iphone 4",Price = 1000m },
                new Product {Description="Iphone 5 S",Price = 2000m },
                new Product {Description="teclado microsoft",Price = 100m },
            };

            return Notifiy(products);

        }

    }
}
