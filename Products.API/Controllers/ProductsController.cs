using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.API.Helpers;
using Products.Application.Features.Product.Commands;
using Products.Application.Features.Product.Queries;
using Products.Application.Interfaces;
using Products.Application.Services;
using Products.Domain.DTOs;
using System.Net;

namespace Products.API.Controllers;

/// <summary>
/// Product controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;

    public ProductsController( IMediator _mediator)
    {
        mediator = _mediator;
    }

    /// <summary>
    /// Get a Product by Id
    /// </summary>
    /// <param name="id">Product Id</param>
    /// <returns>A product instance of <see cref="GetProductResponse"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<GetProductResponse>> GetById(int id)
    {
        try
        {
            var result = await mediator.Send(new GetProduct { Id = id });
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }        
    }

    /// <summary>
    /// Add a Product
    /// </summary>
    /// <param name="newProductDTO">Product instance to be created <see cref="NewProduct"/></param>
    /// <returns>A product instance of <see cref="GetProductResponse"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<GetProductResponse>> InsertProduct(NewProduct newProductDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ErrorMessages.Convert(ModelState));

        try
        {
            var result = await mediator.Send(newProductDTO);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        
    }

    /// <summary>
    /// Update a Product
    /// </summary>
    /// <param name="editProductDTO">Product instance to be update <see cref="EditProduct"/></param>
    /// <returns>A product instance of <see cref="GetProductResponse"/></returns>
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<GetProductResponse>> UpdateProduct(EditProduct editProductDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ErrorMessages.Convert(ModelState));

        try
        {
            var result = await mediator.Send(editProductDTO);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        
    }

}
