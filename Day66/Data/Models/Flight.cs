using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day66.Data.Models;

public class Flight
{
    public int Id { get; set; }

    [Unicode(false)]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int? PlaneModelRefId { get; set; }

    [ForeignKey(nameof(PlaneModelRefId))]
    public PlaneModel PlaneModel { get; set; } = null!;

    public int? FromLocationRefId { get; set; }

    [ForeignKey(nameof(FromLocationRefId))]
    public Location FromLocation { get; set; } = null!;

    public int? ToLocationRefId { get; set; }

    [ForeignKey(nameof(ToLocationRefId))]
    public Location ToLocation { get; set; } = null!;

    public DateTime DepartureDateTime { get; set; }

    public DateTime ReturnDateTime { get; set; }

    public int PricePerAdult { get; set; }
}