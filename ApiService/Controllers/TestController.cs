using ApiService.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly AppDbContext _context;



        public TestController(AppDbContext context)
        {


            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Test()
        {


            try
            {




                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {

                    await _context.choices.AddAsync(new Entities.Choice()
                    {

                        value = "one"
                    });

                    await _context.SaveChangesAsync();






                    throw new Exception("test");

         
               
                    await _context.choices.AddAsync(new Entities.Choice()
                    {

                        value = "two"
                    });

                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();


                    return StatusCode(200, new
                    {


                        message = "done",

                        status = 200,
                        type = "success"
                    });














                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();




                    return StatusCode(500, new
                    {

                        status = 500,
                        body = new
                        {

                            message = ex.Message
                        },
                        type = "internal server error"
                    });
                }

            }catch (Exception ex)
            {

                return StatusCode(500, new
                {

                    status = 500,
                    body = new
                    {

                        message = ex.Message
                    },
                    type = "internal server error"
                });

            }
        }
    }
}
