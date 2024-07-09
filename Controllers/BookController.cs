using Book_Management.Models;
using Book_Management.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Book_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        
        
            private readonly IbookInterface bookrepo;

            public BookController(IbookInterface bookrepo)
            {
                this.bookrepo = bookrepo;
            }

            [HttpPost]
            //[ActionName("Addbooks")]
            public async Task<ActionResult<Book>> Addbooks(Book info)
            {
                try
                {
                    if (info == null)
                    {
                        return BadRequest();
                    }
                    var result = await bookrepo.Addbook(info);
                    return CreatedAtAction(nameof(books), new { id = info.Id }, info); // returnning the record
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            [HttpGet("{id}")]
            public async Task<ActionResult<Book>> books(int id)
            {
                try
                {
                    var result = await bookrepo.Getbook(id);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            [HttpGet]
            public async Task<IActionResult> books()
            {
                try
                {
                    return Ok(await bookrepo.Getbooks());
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            [HttpPut("{id}")]
            //[ActionName("Addbooks")]
            public async Task<ActionResult<Book>> Updatebooks(Book info, int id)
            {
                try
                {
                    if (info == null || id != info.Id)
                    {
                        return BadRequest();
                    }

                    await bookrepo.Updatebook(info);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteBook(int id)
            {
                try
                {
                    var success = await bookrepo.Deletebook(id);
                    if (!success)
                    {
                        return NotFound();
                    }

                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            [HttpGet("filter")]
            public async Task<ActionResult<IEnumerable<Book>>> FilterBooks([FromQuery] string genre, [FromQuery] string author)
            {
                var result = await bookrepo.FilterBooks(genre, author);
                return Ok(result);
            }

        
    }
}
