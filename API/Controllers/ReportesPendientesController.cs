using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ReportesPendientesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReportesPendientesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ReportesPendientesDto>>> Get()
    {
        var reportesPendientes = await _unitOfWork.ReporteGastos
            .GetAllPendientesAsync();
        var reportesPendientesDto = _mapper.Map<List<ReportesPendientesDto>>(reportesPendientes);
        return Ok(reportesPendientesDto);
    }

}
