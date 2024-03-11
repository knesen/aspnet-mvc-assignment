﻿using Infrastructure.Contexts;
using Infrastructure.Models;

namespace Infrastructure.Repositories;

abstract class Repo<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    public virtual async Task<ResponseResult> CreateOneAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseResult
            {
                ContentResult = entity,
                Message = "Created successfully",
                StatusCode = StatusCode.OK,
            };
        }
        catch (Exception ex) 
        {
            return new ResponseResult
            {
                Message = ex.Message,
                StatusCode = StatusCode.ERROR,
            };
        }
        
    }
}
