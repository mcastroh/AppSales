using AutoMapper;
using Sales.Shared.Entites;

namespace Logistics.BackEnd.AutoMapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        #region Tablas => Genéricas

        // <------ Almacén ------>
        CreateMap<Country, BasicTablesDTO>().ReverseMap();
        CreateMap<BasicTablesCreateDTO, Country>().ReverseMap();

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