using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAPI.Models
{

    public class PaymentByMonth
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int MonthId { get; set; }
        [Required]
        public int PersonId { get; set; }
        public int? ChitLiftedMonthId { get; set; }
        public virtual Month Month { get; set; }
        public virtual Person Person { get; set; }
    }
}

