using Microsoft.AspNetCore.Mvc;
using Products.API.Helpers;
using Products.Application.Interfaces;
using Products.Domain.DTOs;
using System.Net;

namespace Products.API.Controllers
{
    /// <summary>
    /// Product controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController( IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Get a Product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>A product instance of <see cref="GetProductDTO"/></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetProductDTO>> GetById(int id)
        {
            try
            {
                return Ok(await productService.GetProductById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Add a Product
        /// </summary>
        /// <param name="newProductDTO">Product instance to be created <see cref="NewProductDTO"/></param>
        /// <returns>A product instance of <see cref="GetProductDTO"/></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetProductDTO>> InsertProduct(NewProductDTO newProductDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ErrorMessages.Convert(ModelState));

            try
            {
                return Ok(await productService.Add(newProductDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a Product
        /// </summary>
        /// <param name="editProductDTO">Product instance to be update <see cref="EditProductDTO"/></param>
        /// <returns>A product instance of <see cref="GetProductDTO"/></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetProductDTO>> UpdateProduct(EditProductDTO editProductDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ErrorMessages.Convert(ModelState));

            try
            {
                return Ok(await productService.Update(editProductDTO));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
