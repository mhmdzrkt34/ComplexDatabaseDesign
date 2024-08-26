using System.ComponentModel.DataAnnotations;

namespace ApiService.Entities
{
    public class Output
    {
        [Key]
        public string Id { get; set; }


        public string type { get; set; }


        public string value { get; set; }


        public Output? NextOutput { get; set; }


        public string? next_output_id { get; set; }


       

        public Output PreviousOutput { get; set; }
        public string? previous_output_id { get; set; }



        public virtual ICollection<Choice> choices { get; set; }


     


        public virtual Choice? previousChoice { get; set; }

        public DateTime time { get; set; }



        public Output()
        {


            Id = Guid.NewGuid().ToString();

            time = DateTime.UtcNow;
        }
    }
}
