using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.API.Data;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;

namespace Sales.API.Controllers;

[ApiController]
[Route("/api/states")]
public class StateController : ExtendedBaseController<StateCreateDTO, State, StateDTO>
{
    public StateController(DataContext context, IMapper mapper) : base(context, mapper)
    {
    }
}