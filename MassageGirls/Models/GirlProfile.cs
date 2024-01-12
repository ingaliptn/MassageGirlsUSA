using System.ComponentModel.DataAnnotations;

namespace MassageGirls.Models
{
    public class GirlProfile
    {
        [Key]
        public int GirlId { get; set; }
        public string GirlName { get; set; }
        public string Photo { get; set; }
        public string Bio { get; set; }
        public string Town { get; set; }
        public int MassageTypeID { get; set; }
        public MassageType MassageType { get; set; }
    }
}
