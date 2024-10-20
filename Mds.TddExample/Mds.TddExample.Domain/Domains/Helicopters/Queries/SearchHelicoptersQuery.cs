using Mds.TddExample.Db;
using Mds.TddExample.Domain.Domains.Helicopters.Models;
using Microsoft.EntityFrameworkCore;

namespace Mds.TddExample.Domain.Domains.Helicopters.Queries
{
    public interface ISearchHelicoptersQuery
    {
        Task<IList<HelicopterModel>> Execute();
    }

    public class SearchHelicoptersQuery : ISearchHelicoptersQuery
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHelicopterModelMapper _mapper;

        public SearchHelicoptersQuery(ApplicationDbContext dbContext, IHelicopterModelMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<HelicopterModel>> Execute()
        {
            var helicopters = await _dbContext.Helicopters.ToListAsync();
            return helicopters.Select(_mapper.MapFrom).ToList();
        }
    }
}
