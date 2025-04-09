using OrganizePro.Models;
using Microsoft.EntityFrameworkCore;
using OrganizePro.DTOs;

namespace OrganizePro.Services;

public class CustomerService(Context.Context context) : EntityBaseService<Customer, Context.Context>(context)
{
    public override async Task<Customer> GetEntityByIdAsync(int id)
    {
        return await _context.Customers
            .Include(c => c.Address)
            .ThenInclude(a => a.City)
            .ThenInclude(city => city.Country)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<CustomerTableDto>> CreateCustomerTableDto()
    {
        var customerData = await _context.Customers
            .Select(customer => new CustomerTableDto
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                AddressLine1 = customer.Address.AddressLine1,
                AddressLine2 = customer.Address.AddressLine2,
                CityName = customer.Address.City.CityName,
                PostalCode = customer.Address.PostalCode,
                CountryName = customer.Address.City.Country.CountryName,
                Phone = customer.Address.Phone
            })
            .ToListAsync();

        return customerData;
    }

}

