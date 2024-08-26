using ApiService.data;
using ApiService.Responces.SeedingResponces.SeedDataResponce;

namespace ApiService.Services.SeedingService
{
    public class SeedingService : ISeedingService
    {

        private readonly AppDbContext _context;

        public SeedingService(AppDbContext context)
        {

            _context = context;
        }
        public async Task<SeedingDataResponceBase> SeedData()
        {
            try
            {

                SeedingDataResponceBase responce = new SeedingDataResponceSuccess()
                {

                    body = new SeedDataResponceSuccessBody()
                    {

                        message = "success"
                    },
                    status = 200,
                    type = "succes"



                };

                return responce;

                




            }catch (Exception ex)
            {


                throw ex;
            }
        }
    }
}
