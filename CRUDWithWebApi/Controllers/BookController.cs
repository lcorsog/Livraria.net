using CRUDWithWebApi.DAL;
using CRUDWithWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public BookController(MyAppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Retorna a lista de todos os livros.
        /// </summary>
        /// <returns>Uma lista de livros ou uma mensagem de erro caso nenhum livro seja encontrado.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var books = _context.Books.ToList();
                if (books.Count == 0)
                {
                    return NotFound("Livros nao encontrados.");
                }
                return Ok(books);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Retorna os dados de um livro específico.
        /// </summary>
        /// <param name="id">ID do livro a ser buscado.</param>
        /// <returns>O livro correspondente ao ID ou uma mensagem de erro caso não seja encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var books = _context.Books.Find(id);
                if (books == null)
                {
                    return NotFound($"Dados do livro {id} nao entrado");
                }
                return Ok(books);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Cria um novo livro no sistema.
        /// </summary>
        /// <param name="model">Objeto contendo os dados do livro a ser criado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpPost]
        public IActionResult Post(Book model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Livro criado");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Atualiza os dados de um livro existente.
        /// </summary>
        /// <param name="model">Objeto contendo os novos dados do livro, incluindo o ID.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpPut]
        public IActionResult Put(Book model)
        {
            if(model == null || model.Id == 0)
            {
                if(model == null)
                {
                    return BadRequest("Os dados do modelo sao invalidos");
                }
                else if(model.Id == 0)
                {
                    return BadRequest($"Livro id {model.Id} invalido");
                }

            }

            try
            {
                var book = _context.Books.Find(model.Id);
                if (book == null)
                {
                    return NotFound($"Livro id  {model.Id} nao econtrado");
                }
                book.Title = model.Title;
                book.Author = model.Author;
                book.PublicationYear = model.PublicationYear;
                book.Genre = model.Genre;

                _context.SaveChanges();
                return Ok("Detalhes do livro atualizados ");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Deleta um livro específico do sistema.
        /// </summary>
        /// <param name="id">ID do livro a ser deletado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var book = _context.Books.Find(id);
                if (book == null)
                {
                    return NotFound($"Produto id {id} nao econtrado");
                }
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok("Livro deletado");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
