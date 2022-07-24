using Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        Ecommerce_Entity context;

        public CustomerRepository(Ecommerce_Entity context)
        {
            this.context = context;
        }

        public List<Customer> GetAll()
        {
            return context.customers.ToList();
        }

        public Customer GetById(int id)
        {
            return context.customers.FirstOrDefault(d=> d.Id == id);
        }

        public void Insert(Customer customer)
        {
            context.Add(customer);
            context.SaveChanges();
        }

        public void Update(int id, Customer customer)
        {
            Customer customerToUpdate = GetById(id);
            customerToUpdate.UserName = customer.UserName;
            customerToUpdate.Email = customer.Email;
            customerToUpdate.PhoneNumber = customer.PhoneNumber;
            customerToUpdate.Address = customer.Address;
            
            
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Customer customer = GetById(id);
            context.customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
