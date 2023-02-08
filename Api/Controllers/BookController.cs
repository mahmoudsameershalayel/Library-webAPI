using Api.Data;
using Api.Dto;
using Api.Interfaces;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository; 
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getBooks()
        {
            var booksDto = _bookRepository.getAllBooks();
            return Ok(booksDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getBookById(int id)
        {
            var bookDto = _bookRepository.findById(id);
            return Ok(bookDto);
        }
        [HttpPost]
        public async Task<IActionResult> addBook(BookDto bookDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookRepository.addBook(bookDto);
            return Ok(bookDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , BookDto bookDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookRepository.updateBook(id, bookDto);
            return Ok(bookDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = _bookRepository.deleteBook(id);
            return Ok(book);
        }
       
    }
}
