using Sales.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities;

public class State : IHaveId
{
    public int Id { get; set; }

    [Display(Name = "Departamento/Estado")]
    [MaxLength(60, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    public Country? Country { get; set; }

    public ICollection<City>? Cities { get; set; }

    [Display(Name = "Ciudades")]
    public int CitiesNumber => Cities == null ? 0 : Cities.Count;
}