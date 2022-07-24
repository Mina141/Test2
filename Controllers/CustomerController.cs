using Final_Project.Models;
using Final_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class CustomerController : Controller
    {

        ICustomerRepository CustomerRepository;
        public CustomerController(ICustomerRepository customer)
        {
            CustomerRepository = customer;

        }
        public IActionResult Index()
        {
            return View(CustomerRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(CustomerRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.Insert(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Customer customer = CustomerRepository.GetById(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.Update(id, customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            CustomerRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
