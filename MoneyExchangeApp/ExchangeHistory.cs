using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MoneyExchangeApp
{
    
    [Table("ExchangeHistory")]
    public partial class ExchangeHistory
    {
        public int Id { get; set; }

        [Required]
        public string FromCurrency { get; set; }

        public double FromAmount { get; set; }

        [Required]
        public string ToCurrency { get; set; }

        public double ToAmount { get; set; }

        public DateTime Date { get; set; }
    }
}
