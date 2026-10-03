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
    public class GenreController : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        public GenreController(IUnitOfWork unitOfWork, IMapper m)
        {
            this.unitOfWork = unitOfWork;
            mapper = m;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            var genres = unitOfWork.genre.GetAll();
            var resulte = mapper.Map<List<GenreDto>>(genres);
            return Ok(resulte);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            var d = unitOfWork.genre.GetById(id);

            if (d == null) { return NotFound(); }
            var resulte = mapper.Map<GenreDto>(d);
            return Ok(resulte);
        }


        [HttpPost]
        public IActionResult Add(CreateGenreDto dto)
        {
            var d = mapper.Map<Genre>(dto);
            unitOfWork.genre.Create(d);
            unitOfWork.Save();
            return CreatedAtAction(nameof(GetGenre) , new { Id = d.Id , Name = d.Name}, d);
        }

        [HttpPut("{id}")]
        public IActionResult AUpdate(int id , CreateGenreDto dto)
        {
            var d = unitOfWork.genre.GetById(id);

            if (d == null) { return NotFound(); }

            mapper.Map(dto, d);
            unitOfWork.genre.Update(d);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var d = unitOfWork.genre.GetById(id);
            if (d == null) { return NotFound(); }
            unitOfWork.genre.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpGet("Retrieve-all-genres-with-their-related-movies")]
        public IActionResult GetGenresWithMovies()
        {
            var genres = unitOfWork.genre.GetGenresWithMovies();

            var result = genres.Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Movies = e.Movies.Select(d => new 
                {
                    Id = d.Id,
                    Title = d.Title,
                    Director = d.Director,
                    GenreId = d.GenreId,
                    GenreName = d.Genre.Name,

                })

            }).ToList();
            return Ok(result);
        }

    }
}
