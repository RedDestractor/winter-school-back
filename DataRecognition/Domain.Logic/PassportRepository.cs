﻿using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Model;

namespace Domain.Logic
{
    public class PassportRepository : IRepository<Passport>
    {
        private readonly string _connectionString;

        public PassportRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task CreateAsync(Passport passport)
        {
            using (var context = new DataContext(_connectionString))
            {
                context.Passports.Add(passport);
                await context.SaveChangesAsync();
            }
        }
    }
}
