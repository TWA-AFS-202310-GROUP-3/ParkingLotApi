﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ParkingLotApi.Exceptions;
using System.Net;

namespace ParkingLotApi.Filters
{
    public class InvalidCapacityExceptionFilter : IActionFilter, IOrderedFilter
    {
        int IOrderedFilter.Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is InvalidCapacityException invalidCapacityException)
            {
                context.Result = new BadRequestResult();
                context.ExceptionHandled = true;
            }
            if (context.Exception is FormatException)
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
