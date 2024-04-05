using QyonAdventureWorks.Properties;
using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Entitys
{
    public class competidores
    {
        [Key]
        public int? id_competidor { get; set; }


        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Messages))]
        public string nome { get; set; }


        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression("^(M|F|O)$", ErrorMessageResourceName = "RangeMessageSex", ErrorMessageResourceType = typeof(Messages))]
        public string sexo { get; set; }


        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Messages))]
        [Range(36, 38, ErrorMessageResourceName = "RangeMessageTemp", ErrorMessageResourceType = typeof(Messages))]
        public decimal? temperaturamediacorpo { get; set; }


        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Messages))]
        [Range(0, double.MaxValue, ErrorMessageResourceName = "RangeMessage", ErrorMessageResourceType = typeof(Messages))]
        public decimal? peso { get; set; }


        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Messages))]
        [Range(0, double.MaxValue, ErrorMessageResourceName = "RangeMessage", ErrorMessageResourceType = typeof(Messages))]
        public decimal? altura { get; set; }
    }
}
