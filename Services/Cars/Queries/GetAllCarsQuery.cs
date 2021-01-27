using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Services.Models;

namespace Services.Cars.Queries
{
    public class GetAllCarsQuery : BaseRequest, IRequest<IEnumerable<Car>>
    {
        public GetAllCarsQuery()
        {
            Console.WriteLine("constructor querry");

        }
    }

    class GetAllCarsQueryHandler:IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {
        public GetAllCarsQueryHandler()
        {
            Console.WriteLine("constructor handel");

        }
        
        public  Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("handle propriuzis");

            return Task.FromResult<IEnumerable<Car>>(new[]
            {
                new Car {Name = $"Ford {request.UserId}"},
                new Car {Name = "Dord"},
            });
        }
    }
}