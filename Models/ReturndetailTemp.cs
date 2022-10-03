using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class ReturndetailTemp
    {
        [Key]
        public int ReturndetailTempID { get; set; }

        public int MovieID {get; set;}

        public string MovieName {get; set;}

    }
}