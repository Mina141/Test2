using Final_Project.Models;

namespace Final_Project.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product product);
        void Update(int id,Product product);
        void Delete(int id);
    }
}
