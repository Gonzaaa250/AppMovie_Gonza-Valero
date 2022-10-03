using System.ComponentModel.DataAnnotations;

namespace AppMovie.Models
{
    public class Return
    {
        [Key]
        public int RetuenID { get; set; }

        [Display(Name = "Fecha de devolucion")]
        [DataType(DataType.Date)]
        public DateTime ReturnlDate { get; set; }


        [Display(Name = "Socio")]
        public int PartnerID { get; set; }
        public virtual Partner? Partner { get; set; }



        public virtual ICollection<ReturnDetail>? ReturnDetail { get; set; }
    }
}