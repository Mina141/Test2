using Final_Project.Models;

namespace Final_Project.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Insert(Customer customer);
        void Update(int id,Customer customer);
        void Delete(int id);
        
    }
}
