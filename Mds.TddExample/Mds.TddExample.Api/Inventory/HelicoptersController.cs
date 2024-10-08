using Mds.TddExample.Domain.Domains.Helicopters.Commands;
using Mds.TddExample.Domain.Domains.Helicopters.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mds.TddExample.Api.Inventory
{
    [Route("helicopters")]
    public class HelicoptersController
    {
        private readonly SearchHelicoptersQuery _searchHelicoptersQuery;
        private readonly GetHelicopterQuery _getHelicopterQuery;
        private readonly UpdateHelicopterCommand _updateHelicopterCommand;
        private readonly CreateHelicopterCommand _createHelicopterCommand;
        private readonly DeleteHelicopterCommand _deleteHelicopterCommand;

        public HelicoptersController(
            SearchHelicoptersQuery searchHelicoptersQuery,
            GetHelicopterQuery getHelicopterQuery,
            UpdateHelicopterCommand updateHelicopterCommand,
            CreateHelicopterCommand createHelicopterCommand,
            DeleteHelicopterCommand deleteHelicopterCommand)
        {
            _searchHelicoptersQuery = searchHelicoptersQuery;
            _getHelicopterQuery = getHelicopterQuery;
            _updateHelicopterCommand = updateHelicopterCommand;
            _createHelicopterCommand = createHelicopterCommand;
            _deleteHelicopterCommand = deleteHelicopterCommand;
        }

        [HttpGet]
        public async Task<IList<HelicopterDto>> Query()
        {
            var helicopters = await _searchHelicoptersQuery.Execute();
            return helicopters.Select(HelicopterDto.MapFrom).ToList();
        }

        [HttpPost]
        public async Task<HelicopterDto> Create(HelicopterDto dto)
        {
            var helicopter = HelicopterDto.MapToHelicopterModel();
            var createdModel = await _createHelicopterCommand.Execute(helicopter);
            return HelicopterDto.MapFrom(createdModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HelicopterDto> Get(int id)
        {
            var helicopter = await _getHelicopterQuery.Execute(id);
            return HelicopterDto.MapFrom(helicopter);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<HelicopterDto> Update(int id, HelicopterDto dto)
        {
            var helicopter = HelicopterDto.MapToHelicopterModel();
            var updatedModel = await _updateHelicopterCommand.Execute(id, helicopter);
            return HelicopterDto.MapFrom(updatedModel);
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
