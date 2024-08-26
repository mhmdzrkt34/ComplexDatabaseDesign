using ApiService.Responces.SeedingResponces.SeedDataResponce;

namespace ApiService.Services.SeedingService
{
    public interface ISeedingService
    {
        public Task<SeedingDataResponceBase> SeedData();
     

    }
}
