using assigment2.Dtos;
using assigment2.Models;
using assigment2.Work;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assigment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControllerController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public CustomerControllerController(IUnitOfWork unitOfWork, IMapper m)
        {
            this.unitOfWork = unitOfWork;
            mapper = m;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = unitOfWork.customer.GetAll();
            var result = mapper.Map<List<CustomerDto>>(customers);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var d = unitOfWork.customer.GetById(id);

            if (d == null) { return NotFound(); }
            var result = mapper.Map<CustomerDto>(d);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add(CreateCustomerDto dto)
        {
            var d = mapper.Map<Customer>(dto);
            unitOfWork.customer.Create(d);
            unitOfWork.Save();
            return CreatedAtAction(nameof(GetCustomer), new { Id = d.Id, Name = d.FullName }, d);
        }

        [HttpPut("{id}")]
        public IActionResult AUpdate(int id, CreateCustomerDto dto)
        {
            var d = unitOfWork.customer.GetById(id);

            if (d == null) { return NotFound(); }

            mapper.Map(dto, d);
            unitOfWork.customer.Update(d);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var d = unitOfWork.customer.GetById(id);
            if (d == null) { return NotFound(); }
            unitOfWork.customer.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpGet("Retrieve-customers-together-with-their-bookings.")]
        public IActionResult Bookinr()
        {
            var customers = unitOfWork.customer.GetCustomersByBooing();

            var r = customers.Select
                (
                n => new
                {
                    Id = n.Id,
                    Name = n.FullName,
                    Books = n.Bookings.Select
                    (
                        b => new
                        {
                            Id = b.Id,
                            MovieName = b.Movie.Title,
                            BookingDate = b.BookingDate,
                            Price = b.Price
                        }
                    )
                }
                ).ToList();
            return Ok(r);

        }



        [HttpGet("Vip")]
        public IActionResult GetVip() 
        {
            var data = unitOfWork.customer.GetVipCustomers();
            var r = mapper.Map<List<CustomerDto>>(data);
            return Ok(r);
        }

        [HttpGet("No-Book")]
        public IActionResult NoBooking()
        {
            var data = unitOfWork.customer.GetCustomersNeverBook();
            var r = mapper.Map<List<CustomerDto>>(data);
            return Ok(r);
        }
    }
}
