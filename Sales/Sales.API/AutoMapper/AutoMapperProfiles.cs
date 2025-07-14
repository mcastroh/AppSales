using AutoMapper;
using Sales.Shared.DTOs;
using Sales.Shared.Entities;

namespace Sales.API.AutoMapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        #region Tablas => Genéricas

        //Mapper.CreateMap<YourEntityViewModel, YourEntity>();

        // <------ Categorías ------>
        CreateMap<Categoria, CategoriaCreateDTO>().ReverseMap();
        CreateMap<CategoriaDTO, Categoria>().ReverseMap();

        // <------ Country ------>
        CreateMap<Country, CountryCreateDTO>().ReverseMap();
        CreateMap<CountryCreateDTO, Country>().ReverseMap();

        //CreateMap<CountryCreateDTO, Country>()
        //    .ForMember(x => x.Id, x => x.Ignore())
        //    .EqualityComparison((a, b) => a.Name == b.Name)
        //    .ReverseMap();

        //CreateMap<AutoresCreateDTO, Autor>().ForMember(m => m.Foto, options => options.Ignore());

        //    public IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>() =>
        //CreateMapCore<TSource, TDestination>(MemberList.Destination);

        // <------ Almacén ------>
        //CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        //CreateMap<CategoriaDTO, Categoria>().ReverseMap();

        //CreateMap<Categoria, CategoriaDTO>().ReverseMap()
        //    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name));

        //        var mapConfig = new MapperConfiguration(
        //   cfg => cfg.CreateMap<Employee, EmployeeDto>()
        //      .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
        //);

        //// <------ Grupo de Productos ------>
        //CreateMap<Grupo, BasicTablesDTO>().ReverseMap();
        //CreateMap<BasicTablesCreateDTO, Grupo>().ReverseMap();

        //// <------ Tipos de Almacén ------>
        //CreateMap<TipoAlmacen, BasicTablesDTO>().ReverseMap();
        //CreateMap<BasicTablesCreateDTO, TipoAlmacen>().ReverseMap();

        //// <------ Tipos de Artículos ------>
        //CreateMap<TipoArticulo, BasicTablesDTO>().ReverseMap();
        //CreateMap<BasicTablesCreateDTO, TipoArticulo>().ReverseMap();

        //// <------ Sunat Tipo Existencias ------>
        //CreateMap<SunatTipoExistencia, BasicTablesDTO>().ReverseMap();
        //CreateMap<BasicTablesCreateDTO, SunatTipoExistencia>().ReverseMap();

        //#endregion Tablas => Genéricas

        //#region Tablas => Especializadas

        //// <------ Parámetro de Configuración ------>
        //CreateMap<ParametroConfiguracion, ParametroConfiguracionDTO>().ReverseMap();
        //CreateMap<ParametroConfiguracionCreateDTO, ParametroConfiguracion>().ReverseMap();

        //// <------ SubGrupo de Productos ------>
        //CreateMap<SubGrupo, SubGrupoDTO>().ReverseMap();
        //CreateMap<SubGrupoCreateDTO, SubGrupo>().ReverseMap();

        //// <------ SubGrupo Detalles de Productos ------>
        //CreateMap<SubGrupoDetalle, SubGrupoDetalleDTO>().ReverseMap();
        //CreateMap<SubGrupoDetalleCreateDTO, SubGrupoDetalle>().ReverseMap();

        //// <------ Sunat Detracciones ------>
        //CreateMap<SunatDetraccion, SunatDetraccionDTO>().ReverseMap();
        //CreateMap<SunatDetraccionCreateDTO, SunatDetraccion>().ReverseMap();

        //
        //
        // <------ Editoriales ------>
        //CreateMap<Editorial, EditorialesDTO>().ReverseMap();
        //CreateMap<Editorial, EditorialesCreateDTO>().ReverseMap();

        //// <------ Libros ------>
        //CreateMap<Libro, LibrosDTO>().ReverseMap();
        //CreateMap<Libro, LibrosCreateDTO>().ReverseMap();

        //// <------ Autores ------>
        //CreateMap<Autor, AutoresDTO>().ReverseMap();
        //CreateMap<AutoresCreateDTO, Autor>().ForMember(m => m.Foto, options => options.Ignore());

        #endregion Tablas => Genéricas
    }
}