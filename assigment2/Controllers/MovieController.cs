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
    public class MovieController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public MovieController(IUnitOfWork unitOfWork, IMapper m)
        {
            this.unitOfWork = unitOfWork;
            mapper = m;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = unitOfWork.movie.GetAll();
            var result = mapper.Map<List<MovieDto>>(movies);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult getMovie(int id)
        {
            var d = unitOfWork.movie.GetById(id);

            if (d == null) { return NotFound(); }
            var result = mapper.Map<MovieDto>(d);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Add(CreateMovieDto dto)
        {
            var d = mapper.Map<Movie>(dto);
            unitOfWork.movie.Create(d);
            unitOfWork.Save();
            return Created();
        }

        [HttpPut]
        public IActionResult Update(int id, CreateMovieDto dto)
        {
            var d = unitOfWork.movie.GetById(id);
            if (d == null) { return NotFound(); }
            mapper.Map(dto, d);
            unitOfWork.movie.Update(d);
            unitOfWork.Save();
            return NoContent();
        }



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var d = unitOfWork.movie.GetById(id);
            if (d == null) { return NotFound(); }
            unitOfWork.movie.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }


        [HttpGet("api/rating")]
        public IActionResult GetMoviesByRating(decimal rating)
        {
            var movies = unitOfWork.movie.GetRatingGreaterThan(rating);
            var result = mapper.Map<List<MovieDto>>(movies);
            return Ok(result);
        }
        [HttpGet("Price-between")]
        public IActionResult GetMoviesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var movies = unitOfWork.movie.GetPriceBetween(minPrice, maxPrice);
            var result = mapper.Map<List<MovieDto>>(movies);
            return Ok(result);
        }



        [HttpGet("available")]
        public IActionResult Available()
        {
            var movies = unitOfWork.movie.GetAvailable();
            var result = mapper.Map<List<MovieDto>>(movies);
            return Ok(result);
        }


        [HttpGet("Get-Top-Rated")]
        public IActionResult TopRated()
        {
            var movies = unitOfWork.movie.GetTopRated();
            var result = mapper.Map<MovieDto>(movies);
            return Ok(result);
        }

        [HttpGet("Get-Latest")]
        public IActionResult Latest()
        {
            var movies = unitOfWork.movie.GetLatest();
            var result = mapper.Map<MovieDto>(movies);
            return Ok(result);
        }

        [HttpGet("most-booked")]
        public IActionResult MostBooked()
        {
            var movies = unitOfWork.movie.GetMostBooked();
            var result = mapper.Map<MovieDto>(movies);
            return Ok(result);
        }

        [HttpGet("GetCount")]
        public IActionResult Count()
        {
            var movies = unitOfWork.movie.GetCount();
            return Ok(movies);
        }

        [HttpGet("average")]
        public IActionResult Average()
        {
            var movies = unitOfWork.movie.GetAveragePrice();
            return Ok(movies);
        }



        [HttpGet("Search")]
        public IActionResult Search(string title)
        {
            var movies = unitOfWork.movie.Search(title);
            var result = mapper.Map<List<MovieDto>>(movies);
            return Ok(result);
        }

        [HttpGet("Genre-Details")]
        public IActionResult GetMoviesWithGenre()
        {
            var movies = unitOfWork.movie.GetMoviesWithGenre();
            var result = movies.Select(e => new
            {
                Id = e.Id,
                MovieTitle = e.Title,
                GenreName = e.Genre.Name
            }).ToList();
                
                return Ok(result);
        }





        [HttpGet("pagination")]
        public IActionResult Pagination(int number , int size)
        {
            var movies = unitOfWork.movie.GetPaged(number, size);
            var result = mapper.Map<List<MovieDto>>(movies);

            return Ok(result);
        }



    }
    }
