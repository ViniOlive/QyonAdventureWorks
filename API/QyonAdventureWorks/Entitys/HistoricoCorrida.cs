﻿using QyonAdventureWorks.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace QyonAdventureWorks.Entitys
{
    public class historicocorrida
    {
        [Key]
        public int? id_historico { get; set; }

        public int? competidorid { get; set; }

        public int? pistacorridaid { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Messages))]
        [DataType(DataType.Date)]
        [ValidationDateAttribute(ErrorMessageResourceName = "ValidationDate", ErrorMessageResourceType = typeof(Messages))]
        public DateTime? datacorrida { get; set; }

        public decimal? tempogasto { get; set; }
    }
    public class ValidationDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime data = Convert.ToDateTime(value);
            return data.Date <= DateTime.Now.Date;
        }
    }
}
