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

        var flightSearchResultViewModel = new FlightSearchResultViewModel();

        //call api
        var uriDeparture = $"https://localhost:7081/api/Flights/{locationFrom}/{locationTo}/{departureDate:dd-MMM-yyyy}";

        var responseTextDeparture = await _httpClient.GetStringAsync(uriDeparture);
        flightSearchResultViewModel.FlightsDepartures = JsonConvert.DeserializeObject<List<FlightViewModel>>(responseTextDeparture);

        if (returnDate != null)
        {
            var uriReturn = $"https://localhost:7081/api/Flights/{locationTo}/{locationFrom}/{returnDate:dd-MMM-yyyy}";
            var responseTextReturn = await _httpClient.GetStringAsync(uriReturn);
            flightSearchResultViewModel.FlightsReturns = JsonConvert.DeserializeObject<List<FlightViewModel>>(responseTextReturn);
        }

        return flightSearchResultViewModel;
    }

    //private static List<FlightViewModel> GetHardCodedArrivals()
    //{
    //    var flightsArrival = new List<FlightViewModel>();
    //    for (var i = 0; i < 10; i++)
    //    {
    //        flightsArrival.Add(new FlightViewModel
    //        {
    //            AirlineName = Faker.Name.Middle(),
    //            PricePerAdult = Faker.RandomNumber.Next(2500, 25000),
    //            Name = Faker.Name.First(),
    //            DepartureTime = DateTime.Now.AddMinutes(Faker.RandomNumber.Next(-5 * 60, 5 * 60)),
    //            ArrivalTime = DateTime.Now.AddMinutes(Faker.RandomNumber.Next(-5 * 60, 5 * 60)),
    //        });
    //    }

    //    return flightsArrival;
    //}

    //private static List<FlightViewModel> GetHardCodedDepartures()
    //{
    //    var flightsDeparture = new List<FlightViewModel>();
    //    for (var i = 0; i < 10; i++)
    //    {
    //        flightsDeparture.Add(new FlightViewModel
    //        {
    //            AirlineName = Faker.Name.Middle(),
    //            PricePerAdult = Faker.RandomNumber.Next(2500, 25000),
    //            Name = Faker.Name.First(),
    //            DepartureTime = DateTime.Now.AddMinutes(Faker.RandomNumber.Next(-5 * 60, 5 * 60)),
    //            Duration = new TimeSpan(Faker.RandomNumber.Next(1, 3), Faker.RandomNumber.Next(0, 60), 0),
    //        });
    //    }

    //    return flightsDeparture;
    //}
}