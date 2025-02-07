using AutoMapper;
using Bookstore.Domain.DTOs;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RT.Comb;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ICombProvider _comb;

        public BookController(IBookRepository bookRepository, IMapper mapper, ICombProvider comb)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _comb = comb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAll()
        {
            var books = await _bookRepository.GetAll();
            var booksDTO = _mapper.Map<IEnumerable<BookDTO>>(books);
            return Ok(booksDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var book = await _bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            var bookDTO = _mapper.Map<BookDTO>(book);

            return Ok(bookDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Add(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            book.Id = _comb.Create();

            _bookRepository.Add(book);
            return await _bookRepository.SaveAllAsync() ? Ok("Successfully registered") : BadRequest("Error when registering");
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            book.Id = id;

            _bookRepository.Update(book);
            return await _bookRepository.SaveAllAsync() ? Ok("Successfully changed") : BadRequest("Error when changing");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var book = await _bookRepository.GetById(id);

            if (book == null)
            {
                return NotFound("Book not found");
            }

            _bookRepository.Remove(book);
            return await _bookRepository.SaveAllAsync() ? Ok("Successfully deleted") : BadRequest("Error when deleting");
        }
    }
}
