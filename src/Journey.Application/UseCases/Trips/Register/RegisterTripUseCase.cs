﻿using Journey.Communication.Requests;
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
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new JourneyException(ResourceErrorMessages.NAME_EMPTY);
        }

        if (request.StartDate.Date < DateTime.UtcNow.Date) 
        {
            throw new JourneyException(ResourceErrorMessages.DATE_TRIP_MUST_BE_LATER_THAN_TODAY);
        }

        if (request.EndDate.Date < request.StartDate.Date)
        {
            throw new JourneyException(ResourceErrorMessages.END_DATE_TRIP_MUST_BE_LATER_START_DATE);
        }
    }
}
