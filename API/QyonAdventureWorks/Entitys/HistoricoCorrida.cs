using System;

namespace QyonAdventureWorks.Entitys
{
    public class HistoricoCorrida
    {
        public int Id { get; set; }

        public int CompetidorId { get; set; }

        public int PistaCorrridaId { get; set; }

        public DateTime DataCorrida { get; set; }

        public decimal TempoGasto { get; set; }
    }
}
