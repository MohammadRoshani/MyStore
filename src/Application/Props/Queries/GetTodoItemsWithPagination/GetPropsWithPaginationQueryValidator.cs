using FluentValidation;

namespace MyStore.Application.Props.Queries.GetTodoItemsWithPagination;

public class GetPropsWithPaginationQueryValidator : AbstractValidator<GetPropsWithPaginationQuery>
{
    public GetPropsWithPaginationQueryValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("CategoryId is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
