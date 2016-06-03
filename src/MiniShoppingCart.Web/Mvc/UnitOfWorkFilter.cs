namespace MiniShoppingCart.Mvc
{
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UnitOfWorkFilter : ActionFilterAttribute
    {
        private readonly DataContext dbContext;

        public UnitOfWorkFilter(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.dbContext.Database.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null || filterContext.ExceptionHandled)
            {
                this.dbContext.Database.CommitTransaction();
            } else {
                this.dbContext.Database.RollbackTransaction();
            }
        }
    }
}
