using System.ComponentModel.DataAnnotations;

namespace MassageGirls.Models
{
    public class Town
    {
        [Key]
        public int TownID { get; set; }
        public string TownName { get; set; }
    }
}
