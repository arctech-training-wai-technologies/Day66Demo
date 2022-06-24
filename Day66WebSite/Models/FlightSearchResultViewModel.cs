namespace Day66WebSite.Models;

public class FlightSearchResultViewModel
{
    public List<FlightViewModel>? FlightsDepartures { get; set; } = null!;
    public List<FlightViewModel>? FlightsReturns { get; set; }
}