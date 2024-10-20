using Mds.TddExample.Db;
using Mds.TddExample.Db.Entities;
using Mds.TddExample.Domain.Common;
using Mds.TddExample.Domain.Domains.Helicopters.Models;
using Mds.TddExample.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Mds.TddExample.Domain.Domains.Helicopters.Commands;

public interface IUpdateHelicopterCommand
{
    Task<HelicopterModel> Execute(int id, HelicopterModel model);
}

public class UpdateHelicopterCommand : IUpdateHelicopterCommand
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IModelMapper<Helicopter, HelicopterModel> _mapper;

    public UpdateHelicopterCommand(ApplicationDbContext dbContext, IModelMapper<Helicopter, HelicopterModel> mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<HelicopterModel> Execute(int id, HelicopterModel model)
    {
        await _dbContext.Helicopters
            .Where(h => h.Id == id)
            .ExecuteUpdateAsync(setters => 
                setters.SetProperty(b => b.Name, model.Name)
            );

        var updated = await _dbContext.Helicopters.FindAsync(id);
        
        if (updated == null)
        {
            throw new NotFoundException("Helicopter not found");
        }

        return _mapper.MapFrom(updated);
    }
}