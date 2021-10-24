using System.Collections.Generic;
using Lyzic.Models;

namespace Lyzic.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel() { Id = 1, Name = "XXX", Price = 1212},
                new ProductModel() { Id = 2, Name = "XXX", Price = 1212}
            });
        }

    }
}