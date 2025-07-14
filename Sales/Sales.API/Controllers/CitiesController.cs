using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.API.Data;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;

namespace Sales.API.Controllers;

[ApiController]
[Route("/api/cities")]
public class CitiesController : ExtendedBaseController<CityCreateDTO, City, CityDTO>
{
    public CitiesController(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}