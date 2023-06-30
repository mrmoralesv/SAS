using API.Dtos;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CatalogoProdServController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CatalogoProdServController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CatalogoProdServDto>>> Get()
    {
        var CatalogoProdOServ = await _unitOfWork.CatalogoProdServs
            .GetAllAsync();
        var CatalogoProdOServDto = _mapper.Map<List<CatalogoProdServDto>>(CatalogoProdOServ);
        return Ok(CatalogoProdOServDto);
    }



    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CatalogoProdServDto>> Get(int id)
    {
        var ProductoOServicio = await _unitOfWork.CatalogoProdServs
            .GetByIdAsync(id);

        if (ProductoOServicio == null)
            return NotFound();
        var objeto = _mapper.Map<CatalogoProdServDto>(ProductoOServicio);
        return _mapper.Map<CatalogoProdServDto>(ProductoOServicio);
    }

}
