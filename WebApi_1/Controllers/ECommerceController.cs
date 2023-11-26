using Microsoft.AspNetCore.Mvc;
using WebApi_1.Dtos;
using WebApi_1.Entities;
using WebApi_1.Services.Abstract;

namespace WebApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommerceController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public ECommerceController(ICustomerService customerService,
            IOrderService orderService, IProductService productService)
        {
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
        }

        // GET: api/<ECommerceController>
        [HttpGet("Customers")]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _customerService.GetAll();
            var dataToReturn = customers.Select(c =>
            {
                return new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                };
            });
            return dataToReturn;
        }

        [HttpGet("Orders")]
        public IEnumerable<OrderDto> GetOrders()
        {
            var orders = _orderService.GetAll();
            var dataToReturn = orders.Select(o =>
            {
                return new OrderDto
                {
                    Id = o.Id,
                    ProductId = o.ProductId,
                    CustomerId = o.CustomerId,
                    OrderTime = o.OrderTime
                };
            });
            return dataToReturn;
        }

        [HttpGet("Products")]
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = _productService.GetAll();
            var dataToReturn = products.Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Discount = p.Discount,
                    Price = p.Price,
                };
            });
            return dataToReturn;
        }

        // GET api/<ECommerceController>/5
        [HttpGet("Customers/{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerService.Get(id);
            if (customer != null)
            {
                var dataToReturn = new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Surname = customer.Surname,
                };
                return Ok(dataToReturn);
            }
            return NotFound();
        }

        [HttpGet("Orders/{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderService.Get(id);
            if (order != null)
            {
                var dataToReturn = new OrderDto
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    OrderTime = order.OrderTime,
                    ProductId = order.ProductId
                };
                return Ok(dataToReturn);
            }
            return NotFound();
        }

        [HttpGet("Products/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.Get(id);
            if (product != null)
            {
                var dataToReturn = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Discount = product.Discount
                };
                return Ok(dataToReturn);
            }
            return NotFound();
        }

        // POST api/<ECommerceController>
        [HttpPost("Customers")]
        public IActionResult PostCustomer([FromBody] CustomerAddDto dto)
        {
            try
            {
                var customer = new Customer
                {
                    Name = dto.Name,
                    Surname = dto.Surname,
                };
                _customerService.Add(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Orders")]
        public IActionResult PostOrder([FromBody] OrderAddDto dto)
        {
            try
            {
                var order = new Order
                {
                    OrderTime = dto.OrderTime,
                    ProductId = dto.ProductId,
                    CustomerId = dto.CustomerId,
                };
                _orderService.Add(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Products")]
        public IActionResult PostProduct([FromBody] ProductAddDto dto)
        {
            try
            {
                var product = new Product
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Discount = dto.Discount
                };
                _productService.Add(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ECommerceController>/5
        [HttpPut("Customers/{id}")]
        public IActionResult PutCustomer(int id, [FromBody] CustomerUpdateDto dto)
        {
            try
            {
                var customer = _customerService.Get(id);
                if (customer == null)
                {
                    return NotFound();
                }
                customer.Name = dto.Name;
                customer.Surname = dto.Surname;
                _customerService.Update(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Orders/{id}")]
        public IActionResult PutOrder(int id, [FromBody] OrderUpdateDto dto)
        {
            try
            {
                var order = _orderService.Get(id);
                if (order == null)
                {
                    return NotFound();
                }
                order.OrderTime = dto.OrderTime;
                order.ProductId = dto.ProductId;
                order.CustomerId = dto.CustomerId;
                _orderService.Update(order);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Products/{id}")]
        public IActionResult PutProduct(int id, [FromBody] ProductUpdateDto dto)
        {
            try
            {
                var product = _productService.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                product.Name = dto.Name;
                product.Price = dto.Price;
                product.Discount = dto.Discount;
                _productService.Update(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE api/<ECommerceController>/5
        [HttpDelete("Customers/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _customerService.Get(id);
                if (customer == null)
                {
                    return NotFound();
                }
                _customerService.Delete(customer.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Orders/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var order = _orderService.Get(id);
                if (order == null)
                {
                    return NotFound();
                }
                _orderService.Delete(order.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _productService.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                _productService.Delete(product.Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Products/GetHigher")]
        public IEnumerable<ProductDto> GetHigherProducts()
        {
            var products = _productService.GetAll().OrderByDescending(p => p.Price).Take(2);
            var dataToReturn = products.Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Discount = p.Discount,
                    Price = p.Price,
                };
            });
            return dataToReturn;
        }

        [HttpGet("Products/GetHigherDiscounts")]
        public IEnumerable<ProductDto> GetHigherDiscountsProducts()
        {
            var products = _productService.GetAll().OrderByDescending(p => p.Discount);
            var dataToReturn = products.Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Discount = p.Discount,
                    Price = p.Price,
                };
            });
            return dataToReturn;
        }


    }
}
