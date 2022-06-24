using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Day66.Data.Models;

public class Location
{
    public int Id { get; set; }

    [Unicode(false)]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Unicode(false)]
    [StringLength(100)]
    public string AirportName { get; set; } = null!;
}