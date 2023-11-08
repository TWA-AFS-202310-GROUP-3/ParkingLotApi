using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;

namespace ParkingLotApi.Filters
{
    public class UsedNameExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => 1;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is UsedNameException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}