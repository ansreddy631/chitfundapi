using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAPI.Models
{
	public class Person
	{
        public int Id { get; set; }
        [MaxLength(50)]
        public string Firstname { get; set; }
        [MaxLength(50)]
        public string Lastname { get; set; }
        [MaxLength(12), MaybeNull]
        public int? PhoneNumber { get; set; }
        public int? MonthId { get; set; }


        public virtual Month? Month { get; set; }
        public virtual ICollection<PaymentByMonth> PaymentByMonths { get; set; }

    }
}

