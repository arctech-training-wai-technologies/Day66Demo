namespace Day66WebSite.Models.Services;

public class HolidayBookingService : IHolidayBookingService
{
    /// <summary>
    /// 1. Get Flight Details from API
    /// 2. Transpose the data into ViewModel
    /// 3. Return the view Model
    /// </summary>
    /// <returns></returns>
    public FlightSearchResultViewModel GetAll(string locationFrom, string locationTo, DateTime departureDate, DateTime? returnDate = null)
    {
        // HardCode some value

        var flightsDepartures = GetHardCodedDepartures();
        var flightsReturns = returnDate != null ? GetHardCodedArrivals() : null;

        //call api


        return new FlightSearchResultViewModel { FlightsDepartures = flightsDepartures, FlightsReturns = flightsReturns };
    }

    private static List<FlightViewModel> GetHardCodedArrivals()
    {
        var flightsArrival = new List<FlightViewModel>();
        for (var i = 0; i < 10; i++)
        {
            flightsArrival.Add(new FlightViewModel
            {
                AirlineName = Faker.Name.Middle(),
                Cost = Faker.RandomNumber.Next(2500, 25000),
                FlightName = Faker.Name.First(),
                FlightDepartureTime = DateTime.Now.AddMinutes(Faker.RandomNumber.Next(-5 * 60, 5 * 60)),
                Duration = new TimeSpan(Faker.RandomNumber.Next(1, 3), Faker.RandomNumber.Next(0, 60), 0)
            });
        }

        return flightsArrival;
    }

    private static List<FlightViewModel> GetHardCodedDepartures()
    {
        var flightsDeparture = new List<FlightViewModel>();
        for (var i = 0; i < 10; i++)
        {
            flightsDeparture.Add(new FlightViewModel
            {
                AirlineName = Faker.Name.Middle(),
                Cost = Faker.RandomNumber.Next(2500, 25000),
                FlightName = Faker.Name.First(),
                FlightDepartureTime = DateTime.Now.AddMinutes(Faker.RandomNumber.Next(-5 * 60, 5 * 60)),
                Duration = new TimeSpan(Faker.RandomNumber.Next(1, 3), Faker.RandomNumber.Next(0, 60), 0),
            });
        }

        return flightsDeparture;
    }
}