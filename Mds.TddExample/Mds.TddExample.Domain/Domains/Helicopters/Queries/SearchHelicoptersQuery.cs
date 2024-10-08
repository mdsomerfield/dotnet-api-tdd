﻿using Mds.TddExample.Db;
using Mds.TddExample.Domain.Domains.Helicopters.Models;
using Microsoft.EntityFrameworkCore;

namespace Mds.TddExample.Domain.Domains.Helicopters.Queries
{
    public class SearchHelicoptersQuery
    {
        private readonly ApplicationDbContext _dbContext;

        public SearchHelicoptersQuery(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<HelicopterModel>> Execute()
        {
            var helicopters = await _dbContext.Helicopters.ToListAsync();
            return helicopters.Select(h => new HelicopterModel(h)).ToList();
        }
    }
}
