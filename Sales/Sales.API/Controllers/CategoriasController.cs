using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.API.Data;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;

namespace Sales.API.Controllers;

[ApiController]
[Route("/api/categorias")]
public class CategoriasController : ExtendedBaseController<CategoriaCreateDTO, Categoria, CategoriaDTO>
{
    public CategoriasController(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}