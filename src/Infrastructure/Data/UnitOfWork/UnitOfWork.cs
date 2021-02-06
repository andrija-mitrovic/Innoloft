﻿using ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
            => _context.Dispose();
    }
}
