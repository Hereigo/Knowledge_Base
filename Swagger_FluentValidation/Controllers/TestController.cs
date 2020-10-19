using System;
using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Swagger_FluentValidation.Models;
using Swagger_FluentValidation.Validators;
using Swashbuckle.Swagger.Annotations;

namespace Swagger_FluentValidation.Controllers
{
    /// <summary>
    /// Verifies that the swagger documentation generator works as expected.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IServiceProvider _serviceProvider;

        public TestController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Retrieves test data.
        /// </summary>
        /// <returns>The test data.</returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "The data was returned successfully.")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "You are not authorized to access this resource.")]
        public IActionResult GetTestData()
        {
            var model = new AddressModelValidatable
            {
                City = "Kanzas"
            };

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateAddressModel([FromQuery] AddressModelValidatable addressModel)
        {
            return Ok(addressModel);
        }

        [HttpPost("fluent-model")]
        public IActionResult CreateAddressModelFV([FromQuery] AddressModel addressModel)
        {
            // Fluent Validation :
            // (also integrated into Swagger in Startup.cs)
            var validator = new AddressModelValidator(_serviceProvider);
            validator.ValidateAndThrow<AddressModel>(addressModel);

            return Ok(addressModel);
        }
    }
}