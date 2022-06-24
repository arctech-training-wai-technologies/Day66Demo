namespace Day66WebSite.Models.Services;

public interface IHolidayBookingService
{
    FlightSearchResultViewModel GetAll(
        string locationFrom, 
        string locationTo,
        DateTime departureDate,
        DateTime? returnDate = null);
}