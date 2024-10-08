﻿using Mds.TddExample.Db;
using Microsoft.EntityFrameworkCore;

namespace Mds.TddExample.Domain.Domains.Helicopters.Commands;

public class DeleteHelicopterCommand
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteHelicopterCommand(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Execute(int id)
    {
        await _dbContext.Helicopters.Where(i => i.Id == id).ExecuteDeleteAsync();
    }
}