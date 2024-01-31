using System.ComponentModel.DataAnnotations;

namespace MassageGirls.Models
{
    public class Town
    {
        [Key]
        public int TownID { get; set; }
        public string TownName { get; set; }
        public string PhoneNumberCall { get; set; }
        public string PhoneNumberStr { get; set; }
        public string EroticHeader { get; set; }
        public string EroticFooter { get; set; }
        public string HappyEndingHeader { get; set; }
        public string HappyEndingFooter { get; set; }
        public string TantraHeader { get; set; }
        public string TantraFooter { get; set; }
        public string CouplesHeader { get; set; }
        public string CouplesFooter { get; set; }
        public string AsianHeader { get; set; }
        public string AsianFooter { get; set; }
        public string NuruHeader { get; set; }
        public string NuruFooter { get; set; }
        public string BodyHeader { get; set; }
        public string BodyFooter { get; set; }
        public string SensualHeader { get; set; }
        public string SensualFooter { get; set; }
    }
}
