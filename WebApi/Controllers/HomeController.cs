using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Cars.Commands;
using Services.Cars.Queries;
using Services.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cars")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public Task<IEnumerable<Car>> Index()
        {
            return mediator.Send(new GetAllCarsQuery());
        }
        
        [HttpPost]
        public Task<Response<Car>> Index([FromBody] CreateCarComand comand)
        {
            Console.WriteLine("controller");
            return mediator.Send(comand);
        }
    }
}