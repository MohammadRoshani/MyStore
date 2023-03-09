using FluentValidation;

namespace MyStore.Application.Props.Commands.UpdateTodoItem;

public class UpdatePropCommandValidator : AbstractValidator<UpdatePropCommand>
{
    public UpdatePropCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
