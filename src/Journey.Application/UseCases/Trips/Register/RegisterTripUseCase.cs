using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripUseCase
    {
        public void Execute(RequestRegisterTripJson request)
        {
            Validate(request);
        }

        private void Validate(RequestRegisterTripJson request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new JourneyException(ResourceErrorMessage.NAME_EMPTY + "\nCondition: string.IsNullOrEmpty(request.Name)");
            }

            if (request.StartDate.Date < DateTime.UtcNow.Date)
            {
                throw new JourneyException(ResourceErrorMessage.DATE_TRIP_MUST_BE_LATER_THAN_TODAY + "\nCondition: request.StartDate.Date < DateTime.UtcNow.Date");
            }

            if (request.EndDate.Date < request.StartDate.Date)
            {
                throw new JourneyException(ResourceErrorMessage.END_DATE_TRIP_MUST_BE_LATER_START_DATE + "\nCondition: request.EndDate.Date < request.StartDate.Date");
            }
        }

        
    }
}
