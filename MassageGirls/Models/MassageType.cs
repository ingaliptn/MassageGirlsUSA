using System.ComponentModel.DataAnnotations;

namespace MassageGirls.Models
{
    public class MassageType
    {
        [Key]
        public int MassageTypeID { get; set; }
        public string TypeName { get; set; }
        public string UrlName { get; set; }
    }
}
