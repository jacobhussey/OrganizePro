using Microsoft.EntityFrameworkCore;
using OrganizePro.Context;
using Tests.Models;

namespace Tests;
public class TestDbContext(DbContextOptions<Context> options) : Context(options) 
{
    public DbSet<TestEntity> Entities { get; set; }
}

