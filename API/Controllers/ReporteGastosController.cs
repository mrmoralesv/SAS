using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ReporteGastosController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReporteGastosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ReporteGastoDto>>> Get()
    {
        var reporteGastos = await _unitOfWork.ReporteGastos
            .GetAllAsync();
        var reporteGastosDto = _mapper.Map<List<ReporteGastoDto>>(reporteGastos);
        return Ok(reporteGastosDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReporteGastoDto>> Get(int id)
    {
        var reporteGasto = await _unitOfWork.ReporteGastos
            .GetByIdAsync(id);

        if (reporteGasto == null)
            return NotFound();
        var objeto = _mapper.Map<ReporteGastoDto>(reporteGasto);
        return _mapper.Map<ReporteGastoDto>(reporteGasto);
    }
}
