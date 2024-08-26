namespace ApiService.Responces.SeedingResponces.SeedDataResponce
{
    public class SeedingDataResponceSuccess : SeedingDataResponceBase
    {
        public override int status { get; set; }

        public SeedDataResponceSuccessBody body { get; set; }
        public override string type { get; set; }
    }


    public class SeedDataResponceSuccessBody
    {



        public string message { get; set; }
    }
}
