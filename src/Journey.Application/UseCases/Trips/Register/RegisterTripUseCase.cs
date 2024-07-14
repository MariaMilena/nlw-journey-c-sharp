using Journey.Communication.Requests;
using Journey.Exception.ExceptionsBase;
using Journey.Exception;
using Journey.Infrastructure.Entities;
using Journey.Infrastructure;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.Register;

public class RegisterTripUseCase
{
    public ResponseShortTripJson Execute(RequestRegisterTripJson request)
    {
        Validate(request);

        var dbContext = new JourneyDbContext();

        var trip = new Trip
        {
            Name = request.Name,
            StartDate = request.StartDate,  
            EndDate = request.EndDate,
        };

        dbContext.Trips.Add(trip);

        dbContext.SaveChanges();

        return new ResponseShortTripJson
        {
            EndDate = trip.EndDate,
            Name = trip.Name,
            StartDate = trip.StartDate,
            Id = trip.Id
        };
    }

    private void Validate(RequestRegisterTripJson request)
    {
        var validator = new RegisterTripValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
