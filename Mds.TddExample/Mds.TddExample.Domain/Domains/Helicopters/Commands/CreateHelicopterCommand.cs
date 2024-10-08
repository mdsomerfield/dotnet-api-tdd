using Mds.TddExample.Db;
using Mds.TddExample.Domain.Domains.Helicopters.Models;

namespace Mds.TddExample.Domain.Domains.Helicopters.Commands;

public class CreateHelicopterCommand
{
    private readonly ApplicationDbContext _dbContext;

    public CreateHelicopterCommand(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HelicopterModel> Execute(HelicopterModel model)
    {
        var entity = model.ToEntity();
        var entry = _dbContext.Helicopters.Add(entity);
        await _dbContext.SaveChangesAsync();
        return new HelicopterModel(entry.Entity);
    }
}