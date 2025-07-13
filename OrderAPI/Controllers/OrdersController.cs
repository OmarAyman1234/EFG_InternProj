using Microsoft.AspNetCore.Mvc;
using OrderAPI.Data.Repositories;
using OrderSharedContent;
using OrderAPI.RabbitMQ;
using Microsoft.AspNetCore.Authorization;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderServices _orderServices;

        public OrdersController(OrderServices orderServices)
        {
            _orderServices = orderServices;
        }


        // GET: api/Orders
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            try
            {
                var orders = await _orderServices.GetOrders();
                return Ok(orders);
            }
            catch (Exception ex) 
            {
                // Optional: log the error
                Console.WriteLine($"Error in Get: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/Orders/:id
        [HttpGet("{id}")]
        public ActionResult<OrderDto> Get(int id)
        {
            var order = _orderServices.GetOrderById(id);
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

            var newOrder = _orderServices.CreateOrder(order);
            if(newOrder != null)
            {
                await RabbitMQProducer.Send(newOrder, "post.orders");
                return Created($"/api/Orders/{newOrder.Id}", newOrder);
            }

            return BadRequest("Check your values and try again.");
        }

        // PUT api/Orders/:id
        [HttpPut("{id}")]
        public ActionResult<OrderDto> Put(int id, EditOrderRequest order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_orderServices.EditOrder(id, order) != null)
            {
                return Ok(_orderServices.GetOrderById(id));
            }

            return NotFound($"Order with id {id} not found");
        }

        // DELETE api/Orders/:id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_orderServices.DeleteOrder(id) == true)
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
