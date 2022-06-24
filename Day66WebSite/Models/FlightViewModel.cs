namespace Day66WebSite.Models;

public class FlightViewModel
{
    public string AirlineName { get; set; } = null!;
    public string FlightName { get; set; } = null!;
    public DateTime FlightDepartureTime { get; set; }
    public TimeSpan Duration { get; set; }
    public int Cost { get; set; }

    public DateTime FlightArrivalTime => FlightDepartureTime.Add(Duration);
    public string FormattedDuration => $"{Duration.Hours}h:{Duration.Minutes}m";
}