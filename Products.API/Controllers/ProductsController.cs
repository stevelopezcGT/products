using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.API.Helpers;
using Products.Application.Features.Product.Create;
using Products.Application.Features.Product.Edit;
using Products.Application.Features.Product.Read;
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

    public ProductsController(IMediator _mediator)
    {
        mediator = _mediator;
    }

    /// <summary>
    /// Get a Product by Id
    /// </summary>
    /// <param name="id">Product Id</param>
    /// <returns>A product instance of <see cref="ProductResponse"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<ProductResponse>> GetById(int id)
    {
        var result = await mediator.Send(new ReadProductQuery { Id = id });

        return Ok(result);
    }

    /// <summary>
    /// Add a Product
    /// </summary>
    /// <param name="newProductDTO">Product instance to be created <see cref="CreateProductCommand"/></param>
    /// <returns>A product instance of <see cref="ProductResponse"/></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<ProductResponse>> InsertProduct([FromBody] CreateProductCommand newProductDTO)
    {
        await mediator.Send(newProductDTO);
        return Ok();
    }

    /// <summary>
    /// Update a Product
    /// </summary>
    /// <param name="editProductDTO">Product instance to be update <see cref="EditProductCommand"/></param>
    /// <returns>A product instance of <see cref="ProductResponse"/></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<ProductResponse>> UpdateProduct([FromBody] EditProductCommand editProductDTO)
    {
        await mediator.Send(editProductDTO);
        return Ok();
    }
}
