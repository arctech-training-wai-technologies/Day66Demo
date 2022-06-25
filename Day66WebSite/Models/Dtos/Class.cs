namespace Day66WebSite.Models.Dtos;

public class PlaneModelDto
{
    public int id { get; set; }
    public string name { get; set; }
    public int maxWeightLoadCapacity { get; set; }
    public int maxFuelLoadCapacity { get; set; }
    public int mileagePerKilometer { get; set; }
    public string registrationNumber { get; set; }
    public DateTime manufacturingDate { get; set; }
}

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

public class LocationDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string airportName { get; set; }
}
