using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DataAPI.Models;

namespace DataAPI.Services
{
	public class AuthService
	{
		public AuthService()
		{
		}

        private readonly MyDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(MyDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public Person Register(Person user, string password)
        {
            user.PasswordHash = HashPassword(password);
            _context.Persons.Add(user);
            _context.SaveChanges();
            return user;
        }

        public string Login(string username, string password)
        {
            var user = _context.Persons.SingleOrDefault(u => u.Username == username);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;

            return GenerateJwtToken(user);
        }

        private string HashPassword(string password)
        {
            using var hmac = new HMACSHA512();
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var hmac = new HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash) == hashedPassword;
        }

        private string GenerateJwtToken(Person user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

