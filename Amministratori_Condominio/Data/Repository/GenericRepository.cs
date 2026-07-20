csharp Repositories/GenericRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;

namespace MyApp.Repositories
{
    public class GenericRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public GenericRepository(AppDbContext db) => _db = db;

        public async Task<List<T>> GetAllAsync() => await _db.Set<T>().ToListAsync();
        public async Task<T> GetByIdAsync(object id) => await _db.Set<T>().FindAsync(id);
        public async Task AddAsync(T entity) { _db.Set<T>().Add(entity); await _db.SaveChangesAsync(); }
        public async Task UpdateAsync(T entity) { _db.Set<T>().Update(entity); await _db.SaveChangesAsync(); }
        public async Task DeleteAsync(T entity) { _db.Set<T>().Remove(entity); await _db.SaveChangesAsync(); }
    }
}
