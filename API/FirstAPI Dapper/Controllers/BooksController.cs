using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class BooksController : Controller 
    {
        private readonly IBookRepository _repository;
        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        } 

        //GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        { 
            return Ok(await _repository.GetAll());
        }

        //GET: api/books/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _repository.GetDetails(id);

            if (book == null)
            {
                return NotFound(); 
            }

            return book; 
        }

        //POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _repository.Insert(book);

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        //PUT: api/books/2
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            var bookinDb = await _repository.GetDetails(id);

            if (bookinDb == null)
            return NotFound();

            await _repository.Update(book);

            return NoContent();
        }

        //DELETE: api/books/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {

            var book = await _repository.GetDetails(id); 

            if (book == null)
                return NotFound();

            await _repository.Delete(id);

            return book;
        }
    }
}
