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
    public class BookingController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public BookingController(IUnitOfWork unitOfWork, IMapper m)
        {
            this.unitOfWork = unitOfWork;
            mapper = m;
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            var bookings = unitOfWork.book.GetAll();
            var result = mapper.Map<List<BookingDto>>(bookings);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Getbook(int id)
        {
            var d = unitOfWork.book.GetById(id);

            if (d == null) { return NotFound(); }
            var result = mapper.Map<BookingDto>(d);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add(CreateBookingDto dto)
        {
            var d = mapper.Map<Booking>(dto);
            unitOfWork.book.Create(d);
            var c = unitOfWork.movie.GetById(dto.MovieId);
            d.Price = c.TicketPrice * d.NumberOfTickets;
            c.AvaillableSeats -= d.NumberOfTickets;
            unitOfWork.Save();
            return Created();
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var d = unitOfWork.book.GetById(id);
            if (d == null) { return NotFound(); }
            var c = unitOfWork.movie.GetById(d.MovieId);
            c.AvaillableSeats += d.NumberOfTickets;

            unitOfWork.book.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpGet("details")]
        public IActionResult Details()
        {
          var bookings = unitOfWork.book.details();
            var r = bookings.Select(
                b => new
                {
                    Id = b.Id,
                    Data = b.BookingDate,
                    CustomerName = b.Customer.FullName,
                    MovieName = b.Movie.Title,
                    GenreName = b.Movie.Genre.Name,
                    NumberOfTickets = b.NumberOfTickets,
                    Price = b.Price
                }
                ).ToList();
          return Ok(r);
        }
        [HttpGet("revenue")]
        public IActionResult Revenue()
        {
            var bookings = unitOfWork.book.Revenue();
       
            
            return Ok(bookings);
        }




    }
}
