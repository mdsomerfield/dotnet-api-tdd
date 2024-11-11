using Mds.TddExample.Domain.Domains.Helicopters.Commands;
using Mds.TddExample.Domain.Domains.Helicopters.Models;
using Mds.TddExample.Domain.Domains.Helicopters.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mds.TddExample.Api.Domains.Helicopters
{
    [Route("helicopters")]
    public class HelicoptersController
    {
        private readonly ISearchHelicoptersQuery _searchHelicoptersQuery;
        private readonly IGetHelicopterQuery _getHelicopterQuery;
        private readonly IUpdateHelicopterCommand _updateHelicopterCommand;
        private readonly ICreateHelicopterCommand _createHelicopterCommand;
        private readonly IDeleteHelicopterCommand _deleteHelicopterCommand;
        private readonly IHelicopterDtoMapper _helicopterDtoMapper;

        public HelicoptersController(
            ISearchHelicoptersQuery searchHelicoptersQuery,
            IGetHelicopterQuery getHelicopterQuery,
            IUpdateHelicopterCommand updateHelicopterCommand,
            ICreateHelicopterCommand createHelicopterCommand,
            IDeleteHelicopterCommand deleteHelicopterCommand,
            IHelicopterDtoMapper helicopterDtoMapper)
        {
            _searchHelicoptersQuery = searchHelicoptersQuery;
            _getHelicopterQuery = getHelicopterQuery;
            _updateHelicopterCommand = updateHelicopterCommand;
            _createHelicopterCommand = createHelicopterCommand;
            _deleteHelicopterCommand = deleteHelicopterCommand;
            _helicopterDtoMapper = helicopterDtoMapper;
        }

        [HttpGet]
        public async Task<IList<HelicopterDto>> Query()
        {
            var helicopters = await _searchHelicoptersQuery.Execute();
            return helicopters.Select(_helicopterDtoMapper.MapFrom).ToList();
        }

        [HttpPost]
        public async Task<HelicopterDto> Create([FromBody] HelicopterDto dto)
        {
            var helicopter = _helicopterDtoMapper.MapTo(dto);
            var createdModel = await _createHelicopterCommand.Execute(helicopter);
            return _helicopterDtoMapper.MapFrom(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HelicopterDto> Get(int id)
        {
            var helicopter = await _getHelicopterQuery.Execute(id);
            return _helicopterDtoMapper.MapFrom(helicopter);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<HelicopterDto> Update(int id, [FromBody] HelicopterDto dto)
        {
            var helicopter = _helicopterDtoMapper.MapTo(dto);
            var updatedModel = await _updateHelicopterCommand.Execute(id, helicopter);
            return _helicopterDtoMapper.MapFrom(updatedModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _deleteHelicopterCommand.Execute(id);
            return true;
        }

    }
}
