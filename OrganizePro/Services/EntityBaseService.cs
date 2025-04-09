using OrganizePro.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace OrganizePro.Services;

public abstract class EntityBaseService<TEntity, TContext>
    where TEntity : EntityBase
    where TContext : DbContext
{
    protected TContext _context;

    protected EntityBaseService(TContext context)
    {
        _context = context;
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(GetAllAsync)}: {ex.Message}");
            throw;
        }
    }

    public virtual async Task<TEntity> GetEntityByIdAsync(int id)
    {
        try
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(GetEntityByIdAsync)}: {ex.Message}");
            throw;
        }
    }

    public async Task CreateEntity(TEntity entity)
    {
        try
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(CreateEntity)}: {ex.Message}");
            throw;
        }
    }

    public async Task UpdateEntity(TEntity entity)
    {
        try
        {
            entity.LastUpdate = DateTime.Now;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(UpdateEntity)}: {ex.Message}");
            throw;
        }
    }

    public async Task DeleteEntity(TEntity entity)
    {
        try
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error in {nameof(DeleteEntity)}: {ex.Message}");
            throw;
        }
    }

}