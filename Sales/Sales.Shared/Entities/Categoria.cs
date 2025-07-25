﻿using Sales.Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities;

public partial class Categoria : IHaveId
{
    public int Id { get; set; }

    [Display(Name = "Categoría")]
    [MaxLength(60, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Name { get; set; } = null!;
}