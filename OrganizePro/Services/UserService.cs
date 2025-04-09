using Microsoft.EntityFrameworkCore;
using OrganizePro.Models;

namespace OrganizePro.Services;

public class UserService(Context.Context context) : EntityBaseService<User, Context.Context>(context)
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