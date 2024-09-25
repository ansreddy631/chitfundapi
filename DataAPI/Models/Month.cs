using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAPI.Models
{
    public class Month
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20), NotNull, Required]
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public virtual ICollection<PaymentByMonth> PaymentByMonths { get; set; }

    }
}

