using FluentValidation;
using TestApi.Dtos;

namespace TestApi.Validators
{
    public class SearchRequestValidator : AbstractValidator<SearchRequest>
    {
        public SearchRequestValidator()
        {
            RuleFor(x => x.TextRequest).MinimumLength(1).MaximumLength(1000);
        }
    }
}
