namespace Day66.Data.Dtos
{
    public class FlightDto
    {
        public string Name { get; set; } = null!;

        public DateTime DepartureDateTime { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public int PricePerAdult { get; set; }
    }
}
