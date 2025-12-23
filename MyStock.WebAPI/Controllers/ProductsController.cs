using Microsoft.AspNetCore.Mvc;
using MyStock.Application.DTOs;
using MyStock.Application.Services;

namespace MyStock.WebAPI.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los productos activos
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todos los productos");
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Obtiene un producto por su identificador
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Producto encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            _logger.LogInformation($"Obteniendo producto con ID: {id}");
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(product);
        }

        /// <summary>
        /// Obtiene un producto por su SKU
        /// </summary>
        /// <param name="sku">Código SKU del producto</param>
        /// <returns>Producto encontrado</returns>
        [HttpGet("sku/{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetBySku(string sku)
        {
            _logger.LogInformation($"Obteniendo producto con SKU: {sku}");
            var product = await _productService.GetProductBySkuAsync(sku);
            if (product == null)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(product);
        }

        /// <summary>
        /// Obtiene productos por categoría
        /// </summary>
        /// <param name="category">Categoría de productos</param>
        /// <returns>Lista de productos de la categoría</returns>
        [HttpGet("category/{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetByCategory(string category)
        {
            _logger.LogInformation($"Obteniendo productos de la categoría: {category}");
            var products = await _productService.GetProductsByCategoryAsync(category);
            return Ok(products);
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="createProductDto">Datos del producto a crear</param>
        /// <returns>Identificador del producto creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation($"Creando nuevo producto: {createProductDto.Name}");
            var productId = await _productService.CreateProductAsync(createProductDto);
            return CreatedAtAction(nameof(GetById), new { id = productId }, new { id = productId });
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <param name="updateProductDto">Datos a actualizar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation($"Actualizando producto con ID: {id}");
            var success = await _productService.UpdateProductAsync(id, updateProductDto);
            if (!success)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(new { message = "Producto actualizado correctamente" });
        }

        /// <summary>
        /// Elimina un producto (desactivación lógica)
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando producto con ID: {id}");
            var success = await _productService.DeleteProductAsync(id);
            if (!success)
                return NotFound(new { message = "Producto no encontrado" });

            return Ok(new { message = "Producto eliminado correctamente" });
        }
    }
}
