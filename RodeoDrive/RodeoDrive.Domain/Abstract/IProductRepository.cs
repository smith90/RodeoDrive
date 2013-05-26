using System.Linq;
using RodeoDrive.Domain.Entities;

namespace RodeoDrive.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        void DeleteProduct(Product product);
    }
}
