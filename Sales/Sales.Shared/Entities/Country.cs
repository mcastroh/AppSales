﻿using Sales.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities;

public class Country : IHaveId
{
    public int Id { get; set; }

    [Display(Name = "País")]
    [MaxLength(60, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;

    public ICollection<State>? States { get; set; }

    public int StatesNumber => States == null ? 0 : States.Count;
}