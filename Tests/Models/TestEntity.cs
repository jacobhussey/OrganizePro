using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using OrganizePro.Models;
using OrganizePro.Services;

namespace Tests.Models;

public class TestEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
}

public class TestEntityService(
    TestDbContext context, 
    NullLogger<TestEntityService> logger
) : EntityBaseService<TestEntity, TestDbContext>(context, logger) { }

