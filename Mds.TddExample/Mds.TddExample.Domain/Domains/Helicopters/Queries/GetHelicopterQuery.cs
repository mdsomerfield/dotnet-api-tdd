using Mds.TddExample.Db;
using Mds.TddExample.Domain.Domains.Helicopters.Models;
using Mds.TddExample.Domain.Exceptions;

namespace Mds.TddExample.Domain.Domains.Helicopters.Queries;

public class GetHelicopterQuery
{
    private readonly ApplicationDbContext _dbContext;

    public GetHelicopterQuery(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HelicopterModel> Execute(int id)
    {
        var entity = await _dbContext.Helicopters.FindAsync(id);

        if (entity == null)
        {
            throw new NotFoundException("Helicopter not found");
        }

        return new HelicopterModel(entity);
    }
}