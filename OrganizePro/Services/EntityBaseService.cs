using OrganizePro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace OrganizePro.Services;

public abstract class EntityBaseService<TEntity, TContext>(
    TContext context, 
    ILogger<EntityBaseService<TEntity, TContext>> logger
)
    where TEntity : EntityBase
    where TContext : DbContext
{
    protected readonly TContext _context = context;
    protected readonly ILogger<EntityBaseService<TEntity, TContext>> _logger = logger;

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        try
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all entities");
            throw new ServiceException("An error occurred while retrieving entities", ex);
        }
    }

    public virtual async Task<TEntity?> GetEntityByIdAsync(int id)
    {
        try
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving entity with ID {id}");
            throw new ServiceException($"An error occurred while retrieving entity {id}", ex);
        }
    }

    public async Task CreateEntityAsync(TEntity entity)
    {
        try
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating entity");
            throw new ServiceException("An error occurred while creating the entity", ex);
        }
    }

    public async Task UpdateEntityAsync(TEntity entity)
    {
        try
        {
            entity.LastUpdate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating entity ID {entity.Id}");
            throw new ServiceException($"An error occurred while updating entity {entity.Id}", ex);
        }
    }

    public async Task DeleteEntityAsync(TEntity entity)
    {
        try
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting entity ID {entity.Id}");
            throw new ServiceException($"An error occurred while deleting entity {entity.Id}", ex);
        }
    }
}

public class ServiceException(
    string message, 
    Exception innerException, 
    int errorCode = 0
) : Exception(message, innerException)
{
    public int ErrorCode { get; } = errorCode;

    public override string ToString()
    {
        return $"ServiceException: {Message} (ErrorCode: {ErrorCode}) | Inner: {InnerException?.Message}";
    }
}
