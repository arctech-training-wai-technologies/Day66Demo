namespace Day66WebSite.Models.Dtos;

public class FlightDto
{
    public int id { get; set; }
    public string name { get; set; }
    public int planeModelRefId { get; set; }
    public PlaneModelDto planeModel { get; set; }
    public int fromLocationRefId { get; set; }
    public LocationDto fromLocation { get; set; }
    public int toLocationRefId { get; set; }
    public LocationDto toLocation { get; set; }
    public DateTime departureDateTime { get; set; }
    public DateTime arrivalDateTime { get; set; }
    public int pricePerAdult { get; set; }
}