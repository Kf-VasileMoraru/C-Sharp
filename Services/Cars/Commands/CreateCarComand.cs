using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Services.Models;

namespace Services.Cars.Commands
{
    public class CreateCarComand : IRequest<Response<Car>>
    {
    }

    class CreateCarComandHandler : IRequestHandler<CreateCarComand, Response<Car>>
    {
        public Task<Response<Car>> Handle(CreateCarComand request, CancellationToken cancellationToken)
        {
            if (false)
            {
                return Task.FromResult(Response.Fail<Car>("vasile este pupkin"));
            }
            return Task.FromResult(Response.Ok(new Car{Name = "Mazda"},"Car created"  ));
        }
    }
}