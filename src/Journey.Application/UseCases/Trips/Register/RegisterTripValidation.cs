using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripValidation : AbstractValidator<RequestRegisterTripJson>
    {
public RegisterTripValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(ResourceErrorMessage.NAME_EMPTY);

            RuleFor(x => x.StartDate.Date)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
                .WithMessage(ResourceErrorMessage.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);

            RuleFor(x => x)
                .Must(x => x.EndDate.Date >= x.StartDate.Date)
                .WithMessage(ResourceErrorMessage.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
        }
    }
}
