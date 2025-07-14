using Sales.Shared.Entities;

namespace Sales.API.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
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
            _context.Countries.Add(new Country
            {
                Name = "Colombia",
                States = new List<State>()
            {
                new State()
                {
                    Name = "Antioquia",
                    Cities = new List<City>() {
                        new City() { Name = "Medellín" },
                        new City() { Name = "Itagüí" },
                        new City() { Name = "Envigado" },
                        new City() { Name = "Bello" },
                        new City() { Name = "Rionegro" },
                    }
                },
                new State()
                {
                    Name = "Bogotá",
                    Cities = new List<City>() {
                        new City() { Name = "Usaquen" },
                        new City() { Name = "Champinero" },
                        new City() { Name = "Santa fe" },
                        new City() { Name = "Useme" },
                        new City() { Name = "Bosa" },
                    }
                },
            }
            });
            _context.Countries.Add(new Country
            {
                Name = "Estados Unidos",
                States = new List<State>()
            {
                new State()
                {
                    Name = "Florida",
                    Cities = new List<City>() {
                        new City() { Name = "Orlando" },
                        new City() { Name = "Miami" },
                        new City() { Name = "Tampa" },
                        new City() { Name = "Fort Lauderdale" },
                        new City() { Name = "Key West" },
                    }
                },
                new State()
                {
                    Name = "Texas",
                    Cities = new List<City>() {
                        new City() { Name = "Houston" },
                        new City() { Name = "San Antonio" },
                        new City() { Name = "Dallas" },
                        new City() { Name = "Austin" },
                        new City() { Name = "El Paso" },
                    }
                },
            }
            });
        }

        await _context.SaveChangesAsync();
    }
}