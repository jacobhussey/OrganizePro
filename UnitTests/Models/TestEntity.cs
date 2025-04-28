using Microsoft.EntityFrameworkCore;
using OrganizePro.Models;
using OrganizePro.Services;

namespace Tests.Models;

public class TestEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
}

public class TestEntityService(TestDbContext context) : EntityBaseService<TestEntity, TestDbContext>(context)
{
}

