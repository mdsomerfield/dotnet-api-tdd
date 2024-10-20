using Mds.TddExample.Db;
using Mds.TddExample.Db.Entities;
using Mds.TddExample.Domain.Common;
using Mds.TddExample.Domain.Domains.Helicopters.Models;
using Mds.TddExample.Domain.Exceptions;

namespace Mds.TddExample.Domain.Domains.Helicopters.Queries;
public interface IGetHelicopterQuery
{
    Task<HelicopterModel> Execute(int id);
}

public class GetHelicopterQuery : IGetHelicopterQuery
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IModelMapper<Helicopter, HelicopterModel> _mapper;

    public GetHelicopterQuery(ApplicationDbContext dbContext, IModelMapper<Helicopter, HelicopterModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<HelicopterModel> Execute(int id)
    {
        var entity = await _dbContext.Helicopters.FindAsync(id);

        if (entity == null)
        {
            throw new NotFoundException("Helicopter not found");
        }

        return _mapper.MapFrom(entity);
    }
}