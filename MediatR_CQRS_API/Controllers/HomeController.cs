using System.Threading.Tasks;
using MediatR;
using MediatR_CQRS_API.CommandsQueries;
using MediatR_CQRS_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace MediatR_CQRS_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Users/{id}")]
        [SwaggerOperation(Summary = "Create User", Description = "Create User action by Command")]
        public async Task<User> GetUserAsync(int id)
        {
            return await _mediator.Send(new GetUserQuery { id = id.ToString() });
        }

        [HttpPost]
        [Route("Users/Create")]
        [SwaggerOperation(Summary = "Create User", Description = "Create User action by Command")]
        public async Task<string> CreateUserAsync(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
