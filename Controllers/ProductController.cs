using Final_Project.Models;
using Final_Project.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        IWebHostEnvironment webHostEnvironment;
        IProductRepository productRepository;

        public ProductController(IProductRepository product, IWebHostEnvironment webHostEnvironment)
        {
            productRepository = product;
            this.webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View(productRepository.GetAll());
        }
       
        public IActionResult Details(int id)
        {
            return View(productRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult New()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(IFormFile Image,Product product)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
                fileStream.Close();
            }

                product.Image = Image.FileName;
            
            if (ModelState.IsValid)
            {
                product.Image = uniqueFileName;
                productRepository.Insert(product);

                return RedirectToAction("Index");

            }
       
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = productRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Update(id, product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            productRepository.Delete(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult uploadImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult uploadImage(IFormFile Image)
        {

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
                fileStream.Close();
            }
            
            return View();
        }
    }
}
