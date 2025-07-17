using Microsoft.AspNetCore.Mvc;
using OrderSharedContent;
using Microsoft.AspNetCore.Authorization;
using OrderAPI.Application.UseCases.OrderUseCase;
using OrderAPI.Application.Interfaces;
using OrderAPI.Domain;

namespace OrderAPI.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IMessageBroker _messageBroker;

        public OrdersController(OrderService orderService, IMessageBroker messageBroker)
        {
            _orderService = orderService;
            _messageBroker = messageBroker;
        }

        // GET: api/Orders
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            try
            {
                var orders = await _orderService.GetAllAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Get: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/Orders/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound($"Order with id {id} not found.");
        }

        // POST api/Orders
        [HttpPost]
        public async Task<ActionResult<int>> Post(CreateOrderRequest order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newOrder = await _orderService.CreateAsync(order);
            if (newOrder != null)
            {
                await _messageBroker.Publish(newOrder, "post.orders");
                return Created($"/api/Orders/{newOrder.Id}", newOrder);
            }
            return BadRequest("Check your values and try again.");
        }

        // PUT api/Orders/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> Put(int id, EditOrderRequest order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var editedOrder = await _orderService.EditAsync(id, order);
            if (editedOrder != null)
            {
                return Ok(editedOrder);
            }
            return NotFound($"Order with id {id} not found");
        }

        // DELETE api/Orders/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _orderService.DeleteAsync(id);
            if (deleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
} 