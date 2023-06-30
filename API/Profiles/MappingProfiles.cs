using API.Dtos;
using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ReporteGasto, ReporteGastoDto>().ReverseMap();

        CreateMap<Factura, FacturaDto>().ReverseMap();

        CreateMap<FacturaDetalle, FacturaDetalleDto>().ReverseMap();

        CreateMap<ReportePendienteDto, ReportesPendientesDto>();

        CreateMap<CatalogoProdServ, CatalogoProdServDto>().ReverseMap();

        CreateMap<ProductoOServicio, ProductoOServicioDto>().ReverseMap();



        //CreateMap<Producto, ProductoAddUpdateDto>()
        //    .ReverseMap()
        //    .ForMember(origen => origen.Categoria, dest => dest.Ignore())
        //    .ForMember(origen => origen.Marca, dest => dest.Ignore());

    }
}
