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