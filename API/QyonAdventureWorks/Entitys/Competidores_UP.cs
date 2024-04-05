using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Entitys
{
    public class Competidores_UP
    {

        [Key]
        public int? id_competidor { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public decimal? temperaturamediacorpo { get; set; }
        public decimal? peso { get; set; }
        public decimal? altura { get; set; }

}
}
