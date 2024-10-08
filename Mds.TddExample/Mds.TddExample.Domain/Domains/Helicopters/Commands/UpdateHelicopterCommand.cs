using Mds.TddExample.Db;
using Mds.TddExample.Domain.Domains.Helicopters.Models;
using Mds.TddExample.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Mds.TddExample.Domain.Domains.Helicopters.Commands;

public class UpdateHelicopterCommand
{
    private readonly ApplicationDbContext _dbContext;

    public UpdateHelicopterCommand(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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

        return new HelicopterModel(updated);
    }
}