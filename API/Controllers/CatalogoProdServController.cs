using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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

    //GET: api/catalogoprodserv
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


    //GET: api/catalogoprodserv/1
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

    //POST: api/catalogoprodserv
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CatalogoProdServAddUpdateDto>> Post(CatalogoProdServAddUpdateDto catalogoDto)
    {
        var catalogo = _mapper.Map<CatalogoProdServ>(catalogoDto);
        _unitOfWork.CatalogoProdServs.Add(catalogo);
        await _unitOfWork.SaveAsync();
        if(catalogo == null)
        {
            return BadRequest();
        }
        catalogoDto.Id = catalogo.Id;
        return CreatedAtAction(nameof(Post), new { id = catalogoDto.Id }, catalogoDto);
    }


    //PUT: api/catalogoprodserv/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CatalogoProdServAddUpdateDto>> Put(int id, [FromBody] CatalogoProdServAddUpdateDto catalogoDto)
    {
        if (catalogoDto == null)
            return NotFound();

        var producto = _mapper.Map<CatalogoProdServ>(catalogoDto);
        _unitOfWork.CatalogoProdServs.Update(producto);
        await _unitOfWork.SaveAsync();
        return catalogoDto;
    }

    //DELETE: api/catalogoprodserv
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var catalogo = await _unitOfWork.CatalogoProdServs.GetByIdAsync(id);
        if (catalogo == null)
            return NotFound();

        _unitOfWork.CatalogoProdServs.Remove(catalogo);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
