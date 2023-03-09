using FluentValidation;

namespace MyStore.Application.Props.Commands.CreateTodoItem;

public class CreatePropCommandValidator : AbstractValidator<CreatePropCommand>
{
    public CreatePropCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
