using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day66.Data.Models;

public class PlaneModel
{
    public int Id { get; set; }

    [Unicode(false)]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    public long MaxWeightLoadCapacity { get; set; }

    public long MaxFuelLoadCapacity { get; set; }

    public int MileagePerKilometer { get; set; }

    [Unicode(false)]
    [StringLength(50)]
    public string RegistrationNumber { get; set; } = null!;

    public DateTime ManufacturingDate { get; set; }
}