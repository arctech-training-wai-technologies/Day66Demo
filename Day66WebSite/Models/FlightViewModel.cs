namespace Day66WebSite.Models;

public class FlightViewModel
{
    //public string AirlineName { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateTime DepartureDateTime { get; set; }
    public DateTime ArrivalDateTime { get; set; }
    public TimeSpan Duration => ArrivalDateTime - DepartureDateTime;
    public int PricePerAdult { get; set; }

    public string FormattedDuration => $"{Duration.Hours}h:{Duration.Minutes}m";
}