using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Swagger_FluentValidation.Data;
using Swagger_FluentValidation.Models;

namespace Swagger_FluentValidation.Validators
{
    public class AddressModelValidator : AbstractValidator<AddressModel>
    {
        private readonly IServiceProvider serviceProvider;

        public AddressModelValidator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            RuleFor(x => x.Line1).NotEmpty();
            RuleFor(x => x.Line1).MaximumLength(100);
            RuleFor(x => x.Line2).MaximumLength(10);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).MaximumLength(100);
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.State).MaximumLength(2);
            RuleFor(x => x.Zip).NotEmpty();
            RuleFor(x => x.Zip).Matches(@"^\d{5}(-?\d{4})?$");
            RuleFor(x => x.State).MustAsync(IsKnownState).When(x => x.State != null);
        }

        private async Task<bool> IsKnownState(string abbreviation, CancellationToken token)
        {
            var stateRepository = serviceProvider.GetRequiredService<IStateRepository>();
            var state = await stateRepository.GetStateAsync(abbreviation, token);
            return state != null;
        }
    }
}