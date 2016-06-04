namespace MiniShoppingCart.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MiniShoppingCart.Infrastructure;
    using ViewModels;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    public class HomeController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.uow.Customers.Add(new Customer("Joe", "Blogs", "joe@test.com", "Address 1", "Address 2", "New York", "NY", "US"));
            this.uow.SaveChanges();
            return View(this.BuildUpHomePageViewModel(new HomePageViewModel()));
        }

        [HttpPost]
        public IActionResult Index(HomePageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: The query logic should be pushed back into a service layer
                var selectedProduct = uow.Products.SingleOrDefault(p => p.Id == viewModel.ProductId);
                if (selectedProduct != null) {

                    // Trivial example, there is only one customer in the system and we will only select 1 item at a time

                    // Retrieve entire customer and shopping cart
                    var customer = uow.Customers
                        .Include(c => c.ShoppingCart)
                        .ThenInclude(sc => sc.Items)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault();

                    customer.ShoppingCart.AddItem(new ShoppingCartItem(selectedProduct, 1));
                    viewModel.CartTotal = customer.ShoppingCart.GetTotalPrice();
                    uow.SaveChanges();
                }
            }

            return View(this.BuildUpHomePageViewModel(viewModel));
        }

        private HomePageViewModel BuildUpHomePageViewModel(HomePageViewModel viewModel)
        {
            viewModel.Products = uow.Products.ToList();
            viewModel.User = uow.Customers.FirstOrDefault(); // Only one customer in the system for demo
            return viewModel;
        }
    }
}
