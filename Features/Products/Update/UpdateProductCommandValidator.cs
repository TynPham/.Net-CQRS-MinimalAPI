using FluentValidation;

namespace CQRS_MinimalAPI.Features.Products.Update;

internal sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.body).NotNull().WithMessage("Body cannot be null");
        RuleFor(x => x.id).GreaterThan(0).WithMessage("Id must be greater than 0");
        
        When(x => x.body != null, () =>
        {
            RuleFor(x => x.body.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.body.Detail).NotEmpty().WithMessage("Detail is required");
            RuleFor(x => x.body.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.body.Quantity).NotEmpty().WithMessage("Quantity is required");
        });
    }
}