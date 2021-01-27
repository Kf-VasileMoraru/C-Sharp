using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Services;
using Services.Models;

namespace WebApi.Infrastructure
{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>
    {
        private HttpContext httpContext;

        public UserIdPipe(IHttpContextAccessor accessor)
        {
            httpContext = accessor.HttpContext;
            Console.WriteLine("constructor pipe");

        }

        public async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {

            var userId = httpContext.User.Claims;
            
            if (request is BaseRequest br)
            {
                br.UserId = "wooo";
            }
            Console.WriteLine("handle pipe");

            var result = await next();

            if (result is Response<Car> carResponse)
            {
                carResponse.Data.Name += "is checked";
            }
            
            return  result;
        }
    }
}