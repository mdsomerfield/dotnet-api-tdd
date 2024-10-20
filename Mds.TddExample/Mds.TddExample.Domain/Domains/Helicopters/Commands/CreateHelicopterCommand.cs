using Mds.TddExample.Db;
using Mds.TddExample.Domain.Domains.Helicopters.Models;

namespace Mds.TddExample.Domain.Domains.Helicopters.Commands;

public interface ICreateHelicopterCommand
{
    Task<HelicopterModel> Execute(HelicopterModel model);
}

public class CreateHelicopterCommand : ICreateHelicopterCommand
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IHelicopterModelMapper _mapper;

    public CreateHelicopterCommand(ApplicationDbContext dbContext, IHelicopterModelMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<HelicopterModel> Execute(HelicopterModel model)
    {
        var entity = _mapper.MapTo(model);
        var entry = _dbContext.Helicopters.Add(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.MapFrom(entry.Entity);
    }
}