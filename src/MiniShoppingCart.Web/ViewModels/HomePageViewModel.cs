namespace MiniShoppingCart.Web.ViewModels
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HomePageViewModel
    {
        public Customer User { get; set; }
        public IList<Product> Products { get; set; }
        public Guid? ProductId { get; set; }
        public decimal CartTotal { get; set; }
    }
}
