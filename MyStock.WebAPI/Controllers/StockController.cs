using Microsoft.AspNetCore.Mvc;
using MyStock.Application.DTOs;
using MyStock.Application.Services;

namespace MyStock.WebAPI.Controllers
{
    /// <summary>
    /// Controlador para la gestión de stock
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly ILogger<StockController> _logger;

        public StockController(IStockService stockService, ILogger<StockController> logger)
        {
            _stockService = stockService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todo el stock
        /// </summary>
        /// <returns>Lista de registros de stock</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetAll()
        {
            _logger.LogInformation("Obteniendo todo el stock");
            var stocks = await _stockService.GetAllStockAsync();
            return Ok(stocks);
        }

        /// <summary>
        /// Obtiene el stock de un producto específico
        /// </summary>
        /// <param name="productId">Identificador del producto</param>
        /// <returns>Stock del producto</returns>
        [HttpGet("product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StockDto>> GetByProductId(int productId)
        {
            _logger.LogInformation($"Obteniendo stock para producto ID: {productId}");
            var stock = await _stockService.GetStockByProductIdAsync(productId);
            if (stock == null)
                return NotFound(new { message = "Stock no encontrado para este producto" });

            return Ok(stock);
        }

        /// <summary>
        /// Obtiene un registro de stock por ID
        /// </summary>
        /// <param name="id">Identificador del stock</param>
        /// <returns>Registro de stock</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StockDto>> GetById(int id)
        {
            _logger.LogInformation($"Obteniendo stock con ID: {id}");
            var stock = await _stockService.GetStockByIdAsync(id);
            if (stock == null)
                return NotFound(new { message = "Stock no encontrado" });

            return Ok(stock);
        }

        /// <summary>
        /// Obtiene productos con stock bajo (por debajo del mínimo)
        /// </summary>
        /// <returns>Lista de productos con stock bajo</returns>
        [HttpGet("low-stock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StockDto>>> GetLowStock()
        {
            _logger.LogInformation("Obteniendo productos con stock bajo");
            var stocks = await _stockService.GetLowStockAsync();
            return Ok(stocks);
        }

        /// <summary>
        /// Crea un nuevo registro de stock para un producto
        /// </summary>
        /// <param name="productId">Identificador del producto</param>
        /// <param name="updateStockDto">Datos del stock a crear</param>
        /// <returns>Identificador del registro de stock creado</returns>
        [HttpPost("product/{productId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(int productId, [FromBody] UpdateStockDto updateStockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation($"Creando stock para producto ID: {productId}");
            var stockId = await _stockService.CreateStockAsync(productId, updateStockDto);
            return CreatedAtAction(nameof(GetById), new { id = stockId }, new { id = stockId });
        }

        /// <summary>
        /// Actualiza un registro de stock
        /// </summary>
        /// <param name="id">Identificador del stock</param>
        /// <param name="updateStockDto">Datos a actualizar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStockDto updateStockDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation($"Actualizando stock con ID: {id}");
            var success = await _stockService.UpdateStockAsync(id, updateStockDto);
            if (!success)
                return NotFound(new { message = "Stock no encontrado" });

            return Ok(new { message = "Stock actualizado correctamente" });
        }

        /// <summary>
        /// Registra un movimiento de stock (entrada, salida o ajuste)
        /// </summary>
        /// <param name="movementDto">Datos del movimiento</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("movement")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddMovement([FromBody] CreateStockMovementDto movementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation($"Registrando movimiento de stock para producto ID: {movementDto.ProductId}");
            var success = await _stockService.AddStockMovementAsync(movementDto);
            if (!success)
                return BadRequest(new { message = "No se pudo registrar el movimiento. Verifique que el producto y cantidad sean válidos." });

            return Ok(new { message = "Movimiento de stock registrado correctamente" });
        }

        /// <summary>
        /// Elimina un registro de stock
        /// </summary>
        /// <param name="id">Identificador del stock</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Eliminando stock con ID: {id}");
            var success = await _stockService.DeleteStockAsync(id);
            if (!success)
                return NotFound(new { message = "Stock no encontrado" });

            return Ok(new { message = "Stock eliminado correctamente" });
        }
    }
}
