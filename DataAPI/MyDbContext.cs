
using DataAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class MyDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Month> Months { get; set; }
    public DbSet<PaymentByMonth> PaymentByMonths { get; set; }
    public DbSet<ChitFund> ChitFunds { get; set; }
    //public DbSet<ChitFund> ChitFunds { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Month>()
            .ToTable("Months");

        modelBuilder.Entity<Person>()
            .ToTable("Persons")
            .HasOne(p => p.Month)
            .WithMany(d => d.Persons)
            .HasForeignKey(p => p.MonthId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PaymentByMonth>()
            .ToTable("PaymentByMonths")
            .HasOne(p => p.Month)
            .WithMany(d => d.PaymentByMonths)
            .HasForeignKey(p => p.MonthId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PaymentByMonth>()
            .ToTable("PaymentByMonths")
            .HasOne(p => p.Person)
            .WithMany(d => d.PaymentByMonths)
            .HasForeignKey(p => p.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        //modelBuilder.Entity<ChitFund>()
        //    .ToTable("ChitFunds");


    }
}