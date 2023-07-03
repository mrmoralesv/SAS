using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductoOServicioController: BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductoOServicioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    //GET: api/productooservicio
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoOServicioDto>>> Get()
    {
        var productoOServicio = await _unitOfWork.ProductoOServicios
            .GetAllAsync();
        var productoOServicioDto = _mapper.Map<List<ProductoOServicioDto>>(productoOServicio);
        return Ok(productoOServicioDto);
    }


    //GET: api/productooservicio/1
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoOServicioDto>> Get(int id)
    {
        var productoOServicio = await _unitOfWork.ProductoOServicios
            .GetByIdAsync(id);

        if (productoOServicio == null)
            return NotFound();
        var objeto = _mapper.Map<ProductoOServicioDto>(productoOServicio);
        return _mapper.Map<ProductoOServicioDto>(productoOServicio);
    }

    //POST: api/productooservicio
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoOServicioAddUpdateDto>> Post(ProductoOServicioAddUpdateDto productoOServicioDto)
    {
        var productoOServicio = _mapper.Map<ProductoOServicio>(productoOServicioDto);
        _unitOfWork.ProductoOServicios.Add(productoOServicio);
        await _unitOfWork.SaveAsync();
        if (productoOServicio == null)
        {
            return BadRequest();
        }
        productoOServicioDto.Id = productoOServicio.Id;
        return CreatedAtAction(nameof(Post), new { id = productoOServicioDto.Id }, productoOServicioDto);
    }


    //PUT: api/productooservicio/4
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoOServicioAddUpdateDto>> Put(int id, [FromBody] ProductoOServicioAddUpdateDto productoOServicioDto)
    {
        if (productoOServicioDto == null)
            return NotFound();

        var productoOServicio = _mapper.Map<ProductoOServicio>(productoOServicioDto);
        _unitOfWork.ProductoOServicios.Update(productoOServicio);
        await _unitOfWork.SaveAsync();
        return productoOServicioDto;
    }

    //DELETE: api/productooservicio/1
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var productoOServicio = await _unitOfWork.ProductoOServicios.GetByIdAsync(id);
        if (productoOServicio == null)
            return NotFound();

        _unitOfWork.ProductoOServicios.Remove(productoOServicio);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
