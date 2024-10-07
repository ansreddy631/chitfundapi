using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataAPI.Models
{
        public class ChitFund
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
            public int UserId { get; set; }
            public Person User { get; set; } // Owner of the chit fund
        }
}

