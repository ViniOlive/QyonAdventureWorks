using QyonAdventureWorks.Properties;
using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Entitys
{
    public class pistacorrida
    {
        [Key]
        public int? id_pista { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Messages))]
        public string descricao { get; set; }
    }
}