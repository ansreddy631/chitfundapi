using System;
using DataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DataAPI.Controllers
{
	public class ChitFundController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ChitFundController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetChitFunds()
        {
            var chitFunds = _context.ChitFunds.ToList();
            return Ok(chitFunds);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateChitFund(ChitFund chitFund)
        {
            _context.ChitFunds.Add(chitFund);
            _context.SaveChanges();
            return Ok(chitFund);
        }
    }
}

