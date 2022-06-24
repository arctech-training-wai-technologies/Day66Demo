namespace Day66.Data.Dtos
{
    public class FlightDto
    {
        public string Name { get; set; } = null!;

        public DateTime DepartureTime { get; set; }

        public DateTime ReturnTime { get; set; }

        public int PricePerAdult { get; set; }
    }
}
