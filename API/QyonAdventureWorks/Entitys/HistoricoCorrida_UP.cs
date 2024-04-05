using QyonAdventureWorks.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Entitys
{
    public class HistoricoCorrida_UP
    {
        [Key]
        public int? id_historico { get; set; }

        public int? competidorid { get; set; }

        public int? pistacorridaid { get; set; }

        [DataType(DataType.Date)]
        [ValidationDateAttribute(ErrorMessageResourceName = "ValidationDate", ErrorMessageResourceType = typeof(Messages))]
        public DateTime? datacorrida { get; set; }

        public decimal? tempogasto { get; set; }
    }
}
