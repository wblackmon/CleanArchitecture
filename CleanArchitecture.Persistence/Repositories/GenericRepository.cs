﻿using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly CleanArchitectureDbConext _context;
    public GenericRepository(CleanArchitectureDbConext context)
    {
        _context = context;
    }
    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        // var entity = await _context.Set<T>().AsNoTracking().FindAsync(id);

        // Copilot help with commented query above
        var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
