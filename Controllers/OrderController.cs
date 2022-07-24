using Final_Project.Models;
using Final_Project.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class OrderController : Controller
    {

        IOrderRepository orderRepository;
        ICustomerRepository customerRepository;

        //After registeration, Injection occurs 
        public OrderController(IOrderRepository order,ICustomerRepository customer)
        {
           orderRepository = order;
           customerRepository = customer;
        }
        public IActionResult Index()
        {
            return View(orderRepository.GetAll());
        }

        public IActionResult Detalis(int id)
        {
            return View(orderRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["Cust_List"] = customerRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.Insert(order);
                return RedirectToAction("Index");
            }

            ViewData["Cust_List"] = customerRepository.GetAll();
            return View(order);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Cust_List"] = customerRepository.GetAll();
            Order order=orderRepository.GetById(id);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , Order order)
        {
            if (ModelState.IsValid)
            {
                orderRepository.Update(id, order);
                return RedirectToAction("Index");
            }
            
            ViewData["Cust_List"] = customerRepository.GetAll();
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            orderRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
