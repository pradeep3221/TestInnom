using TestInnom.Product.DataModels.Models;

namespace TestInnom.Product.Manager
{
    public interface IProductManager : IBaseManager<ProductDto>
    {
    }

    public class ProductManager : BaseManager<ProductDto>, IProductManager
    {
    }
}
