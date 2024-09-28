using FluentValidation;

namespace CQRS_MinimalAPI.Features.Products.Delete;

internal sealed class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.id).GreaterThan(0).WithMessage("Id must be greater than 0");
    }
}