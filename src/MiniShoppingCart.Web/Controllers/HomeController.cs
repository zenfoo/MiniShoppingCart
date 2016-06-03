namespace MiniShoppingCart.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MiniShoppingCart.Infrastructure;

    public class HomeController : Controller
    {
        private readonly IUnitOfWork uow;

        public HomeController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public IActionResult Index()
        {
            var customer = uow.Customers.FirstOrDefault();
            return View(customer);
        }
    }
}
