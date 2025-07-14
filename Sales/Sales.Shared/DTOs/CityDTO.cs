using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.DTOs;

public class CityDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int StateId { get; set; }
}