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



        CreateMap<CatalogoProdServ, CatalogoProdServAddUpdateDto>()
            .ReverseMap()
            .ForMember(origen => origen.ProductoOServicios, dest => dest.Ignore());


        CreateMap<ProductoOServicio, ProductoOServicioAddUpdateDto>()
            .ReverseMap()
            .ForMember(origen => origen.CatalogoProdServ, dest => dest.Ignore());


    }
}
