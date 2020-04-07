using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestInnom.Product.DataModels.Models;
using TestInnom.Product.Manager;

namespace TestInnom.Product.Api.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : MyBaseController<ProductDto>
    {
        public ProductController(IBaseManager<ProductDto> BaseManager) : base(BaseManager)
        {
        }
    }
}
