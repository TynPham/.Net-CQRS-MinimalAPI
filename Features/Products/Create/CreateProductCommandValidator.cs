using FluentValidation;

namespace CQRS_MinimalAPI.Features.Products.Create;

internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Request).NotNull().WithMessage("Request cannot be null");

        When(x => x.Request != null, () =>
        {
            RuleFor(x => x.Request.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Request.Detail).NotEmpty().WithMessage("Detail is required");
            RuleFor(x => x.Request.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Request.Quantity).NotEmpty().WithMessage("Quantity is required");
        } );
    }
}