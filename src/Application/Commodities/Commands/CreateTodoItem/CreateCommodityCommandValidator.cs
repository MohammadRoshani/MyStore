using FluentValidation;

namespace MyStore.Application.Commodities.Commands.CreateTodoItem;

public class CreateCommodityCommandValidator : AbstractValidator<CreateCommodityCommand>
{
    public CreateCommodityCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
