using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.DTOs;

public class CityCreateDTO
{
    [Display(Name = "Ciudad")]
    [MaxLength(60, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    public int StateId { get; set; }
}