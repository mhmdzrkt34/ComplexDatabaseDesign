using System.ComponentModel.DataAnnotations;

namespace ApiService.Entities
{
    public class Choice
    {
        [Key]
        public string id { get; set; }

        public string value { get; set; }



        public virtual Output previousOutput { get; set; }

        public string? previous_output_id { get; set; }


        public string? next_output_id { get; set; }

        public virtual Output nextOutput { get; set;}

        public DateTime time {  get; set; }



        public Choice()
        {

            id = Guid.NewGuid().ToString();

            time = DateTime.UtcNow;
        }
    }
}
