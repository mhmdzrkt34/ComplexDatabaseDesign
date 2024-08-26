using ApiService.Responces.SeedingResponces.SeedDataResponce;
using ApiService.Services.SeedingService;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SeedingController : ControllerBase
    {

        private readonly ISeedingService _seedingService;


        public SeedingController(ISeedingService seedingService)
        {


            _seedingService = seedingService;
        }

        [HttpGet]

        public async Task<IActionResult> SeedData()
        {

            try
            {


                SeedingDataResponceBase responce = await _seedingService.SeedData();


                return StatusCode(responce.status, responce);


            }
            catch (Exception ex)
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
