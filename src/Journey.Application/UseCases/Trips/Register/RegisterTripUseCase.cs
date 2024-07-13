using Journey.Communication.Requests;

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
                throw new ArgumentException("Nome não pode ser vazio");
            }

            if (request.StartDate < DateTime.UtcNow)
            {
                throw new ArgumentException("Data de início não pode ser menor que a data atual");
            }

            if (request.EndDate < request.StartDate)
            {
                throw new ArgumentException("Data de término não pode ser menor que a data de início");
            }
        }

        
    }
}
