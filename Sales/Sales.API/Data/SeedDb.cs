﻿using Microsoft.EntityFrameworkCore;
using Sales.API.Services;
using Sales.Shared.Entities;
using Sales.Shared.Responses;

namespace Sales.API.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IApiService _apiService;

    public SeedDb(DataContext context, IApiService apiService)
    {
        _context = context;
        _apiService = apiService;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckCategoriasAsync();
    }

    private async Task CheckCategoriasAsync()
    {
        if (!_context.Categorias.Any())
        {
            _context.Categorias.Add(new Categoria { Name = "Alimentos" });
            _context.Categorias.Add(new Categoria { Name = "Belleza" });
            _context.Categorias.Add(new Categoria { Name = "Deportes" });
            _context.Categorias.Add(new Categoria { Name = "Electrodomésticos" });
            _context.Categorias.Add(new Categoria { Name = "Higiene y Salud" });
            _context.Categorias.Add(new Categoria { Name = "Maquillaje" });
            _context.Categorias.Add(new Categoria { Name = "Ropa" });
            _context.Categorias.Add(new Categoria { Name = "Tecnología" });
        }

        await _context.SaveChangesAsync();
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            Response responseCountries = await _apiService.GetListAsync<CountryResponse>("/v1", "/countries");

            if (responseCountries.IsSuccess)
            {
                List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result!;
                foreach (CountryResponse countryResponse in countries)
                {
                    Country country = await _context.Countries!.FirstOrDefaultAsync(c => c.Name == countryResponse.Name!)!;
                    if (country == null)
                    {
                        country = new() { Name = countryResponse.Name!, States = new List<State>() };
                        Response responseStates = await _apiService.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                        if (responseStates.IsSuccess)
                        {
                            List<StateResponse> states = (List<StateResponse>)responseStates.Result!;
                            foreach (StateResponse stateResponse in states!)
                            {
                                State state = country.States!.FirstOrDefault(s => s.Name == stateResponse.Name!)!;
                                if (state == null)
                                {
                                    state = new() { Name = stateResponse.Name!, Cities = new List<City>() };
                                    Response responseCities = await _apiService.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                    if (responseCities.IsSuccess)
                                    {
                                        List<CityResponse> cities = (List<CityResponse>)responseCities.Result!;
                                        foreach (CityResponse cityResponse in cities)
                                        {
                                            if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                            {
                                                continue;
                                            }
                                            City city = state.Cities!.FirstOrDefault(c => c.Name == cityResponse.Name!)!;
                                            if (city == null)
                                            {
                                                state.Cities.Add(new City() { Name = cityResponse.Name! });
                                            }
                                        }
                                    }
                                    if (state.CitiesNumber > 0)
                                    {
                                        country.States.Add(state);
                                    }
                                }
                            }
                        }
                        if (country.StatesNumber > 0)
                        {
                            _context.Countries.Add(country);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            }
        }

        //if (!_context.Countries.Any())
        //{
        //    _context.Countries.Add(new Country
        //    {
        //        Name = "Colombia",
        //        States = new List<State>()
        //    {
        //        new State()
        //        {
        //            Name = "Antioquia",
        //            Cities = new List<City>() {
        //                new City() { Name = "Medellín" },
        //                new City() { Name = "Itagüí" },
        //                new City() { Name = "Envigado" },
        //                new City() { Name = "Bello" },
        //                new City() { Name = "Rionegro" },
        //            }
        //        },
        //        new State()
        //        {
        //            Name = "Bogotá",
        //            Cities = new List<City>() {
        //                new City() { Name = "Usaquen" },
        //                new City() { Name = "Champinero" },
        //                new City() { Name = "Santa fe" },
        //                new City() { Name = "Useme" },
        //                new City() { Name = "Bosa" },
        //            }
        //        },
        //    }
        //    });
        //    _context.Countries.Add(new Country
        //    {
        //        Name = "Estados Unidos",
        //        States = new List<State>()
        //    {
        //        new State()
        //        {
        //            Name = "Florida",
        //            Cities = new List<City>() {
        //                new City() { Name = "Orlando" },
        //                new City() { Name = "Miami" },
        //                new City() { Name = "Tampa" },
        //                new City() { Name = "Fort Lauderdale" },
        //                new City() { Name = "Key West" },
        //            }
        //        },
        //        new State()
        //        {
        //            Name = "Texas",
        //            Cities = new List<City>() {
        //                new City() { Name = "Houston" },
        //                new City() { Name = "San Antonio" },
        //                new City() { Name = "Dallas" },
        //                new City() { Name = "Austin" },
        //                new City() { Name = "El Paso" },
        //            }
        //        },
        //    }
        //    });
        //}

        //await _context.SaveChangesAsync();
    }
}