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
            _context.Countries.Add(new Country { Name = "Perú" });
            _context.Countries.Add(new Country { Name = "Colombia" });
            _context.Countries.Add(new Country { Name = "Estados Unidos" });
        }

        await _context.SaveChangesAsync();
    }
}