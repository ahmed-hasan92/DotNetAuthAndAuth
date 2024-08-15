using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnnlineStore.Models.Domain;
using OnnlineStore.Models.DTO;
using OnnlineStore.Repositories;

namespace OnnlineStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool isAscending)
        {
            var books = await bookRepository.GetAllAsync(filterOn, filterQuery , sortBy , isAscending);

            var booksDto = mapper.Map<List<BookDto>>(books);

            return Ok(booksDto);
        }

        [HttpGet]
        [Route("{Id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var book = await bookRepository.GetAsync(Id);

            if (book == null)
            {

                return NotFound("The book you are trying access is unavailable");
            }

            return Ok(mapper.Map<BookDto>(book));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        
        public async Task<IActionResult> AddBook([FromBody] AddRequestBookDto addRequestBookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = mapper.Map<Book>(addRequestBookDto);

            book = await bookRepository.AddAsync(book);

            var bookDto = mapper.Map<BookDto>(book);

            return CreatedAtAction(nameof(GetById), new { Id = bookDto.Id }, bookDto);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("{Id:Guid}")]

        public async Task<IActionResult> UpdateBook([FromRoute] Guid Id, [FromBody] UpdateRequestBookDto updateRequestBookDto)
        {
            var book = mapper.Map<Book>(updateRequestBookDto);

            book = await bookRepository.UpdateAsync(Id,book);

            if (book == null)
            {
                return NotFound("The book you're trying to access is not found");
            }

            var bookDto = mapper.Map<BookDto>(book);
            return Ok(bookDto);

        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("{Id:Guid}")]

        public async Task<IActionResult> DeletBook([FromRoute] Guid Id)
        {
            var book = await bookRepository.DeleteAsync(Id);
            if(book == null)
            {
                return NotFound("The book you're trying to delete is not found!");
            }

            return Ok(mapper.Map<BookDto>(book));
        }
        

    }
}