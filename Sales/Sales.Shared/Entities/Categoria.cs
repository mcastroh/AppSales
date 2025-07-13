using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sales.Shared.Entities;

public partial class Categoria
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("IdCategoria")]
    public int IdCategoria { get; set; }

    [Display(Name = "Categoría")]
    [MaxLength(60, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string? Descripcion { get; set; }

    [Display(Name = "¿Activo?")]
    public bool? EsActivo { get; set; }

    [Display(Name = "Fecha Registro")]
    public DateTime? FechaRegistro { get; set; }

    //public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}