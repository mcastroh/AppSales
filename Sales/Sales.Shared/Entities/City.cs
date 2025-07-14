using Sales.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities;

public class City : IHaveId
{
    public int Id { get; set; }

    [Display(Name = "Ciudad")]
    [MaxLength(60, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    public State? State { get; set; }
}