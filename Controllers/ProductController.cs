using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface.Manager;
using WebApplication1.Manager;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private IProductManager _productManager = new ProductManager();
        public IActionResult Index()
        {
            var products = _productManager.GetAll();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.ProductId = Guid.NewGuid().ToString();
            bool isSaved = _productManager.Add(product);
            string msg = "";
            if(isSaved)
            {
                return RedirectToAction("Index");
            }
            else
            {
                msg = "Failed to Save";
            }
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Edit(String id)
        {
            var product = _productManager.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            bool isUpdated = _productManager.Update(product.ProductId, product);
            if (isUpdated)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Details(string id)
        {
            var product= _productManager.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public ActionResult Delete(string id) {
            var product = _productManager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(Product product)
        {
           bool isDelete = _productManager.Delete(product.ProductId);
            if(isDelete)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Msg = "Failed to delete the product";
            return View(product);
        }
    }
}
