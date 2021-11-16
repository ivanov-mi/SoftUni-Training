﻿using Suls.Data;
using Suls.Data.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Suls.Services
{
    class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };

            db.Users.Add(user);
            db.SaveChanges();
        }


        public string GetUserId(string username, string password)
        {
            var passwordHash = ComputeHash(password);
            var user = this.db.Users
                .FirstOrDefault(u => u.Username == username && u.Password == passwordHash);

            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(u => u.Email == email);
        }

        public bool IsUserNameAvailable(string username)
        {
            return !this.db.Users.Any(u => u.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}
