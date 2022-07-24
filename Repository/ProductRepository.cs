using Final_Project.Models;

namespace Final_Project.Repository
{
    public class ProductRepository : IProductRepository
    {
        Ecommerce_Entity context;

        public ProductRepository(Ecommerce_Entity context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(d => d.Id == id);
        }

        public void Insert(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

       
        public void Update(int id, Product product)
        {
            Product oldProduct = GetById(id);
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            oldProduct.Color = product.Color;
            oldProduct.Image=product.Image;
            oldProduct.Quantity=product.Quantity;
            oldProduct.Description=product.Description;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = GetById(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
