using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrganizePro.Models;

namespace OrganizePro.Services;

public class UserService(Context.Context context, ILogger<UserService> logger) : 
    EntityBaseService<User, Context.Context>(context, logger)
{
    public async Task<bool> ValidateLogin(User user)
    {
        bool isValid = await _context.Users
            .AnyAsync(u => u.Username.ToLower() == user.Username.ToLower() &&
                           u.Password == user.Password);

        return isValid;
    }

    public async Task<bool> ValidateCreate(User user)
    {
        bool isNotValid = await _context.Users
            .AnyAsync(u => u.Username.ToLower() == user.Username.ToLower());
        
        if (isNotValid)
        {
            return false;
        }

        return true;
    }
}