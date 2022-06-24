using Newtonsoft.Json;

namespace Day66WebSite.Models.Services;

public class HolidayBookingService : IHolidayBookingService
{
    private readonly HttpClient _httpClient;

    public HolidayBookingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// 1. Get Flight Details from API
    /// 2. Transpose the data into ViewModel
    /// 3. Return the view Model
    /// </summary>
    /// <returns></returns>
    public async Task<FlightSearchResultViewModel> GetAll(string locationFrom, string locationTo,
        DateTime departureDate, DateTime? returnDate = null)
    {
        // HardCode some value

        //var flightsDepartures = GetHardCodedDepartures();
        //var flightsReturns = returnDate != null ? GetHardCodedArrivals() : null;

        //call api
        var uriDeparture = $"https://localhost:7081/api/Flights/{locationFrom}/{locationTo}/{departureDate}";
        var flightsDeparturesViewModel = await _httpClient.GetFromJsonAsync<List<FlightViewModel>>(uriDeparture);
        //var flightsDeparturesViewModel = JsonConvert.DeserializeObject<List<FlightViewModel>>(responseTextDeparture);

        var uriReturn = $"https://localhost:7081/api/Flights/{locationTo}/{locationFrom}/{returnDate}";
        var flightsReturnsViewModel = await _httpClient.GetFromJsonAsync<List<FlightViewModel>>(uriReturn);
        //var flightsReturnsViewModel = JsonConvert.DeserializeObject<List<FlightViewModel>>(responseTextReturn);

        return new FlightSearchResultViewModel { FlightsDepartures = flightsDeparturesViewModel, FlightsReturns = flightsReturnsViewModel };
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