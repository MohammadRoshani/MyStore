using FluentValidation;

namespace MyStore.Application.Commodities.Commands.UpdateTodoItem;

public class UpdateCommodityCommandValidator : AbstractValidator<UpdateCommodityCommand>
{
    public UpdateCommodityCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
