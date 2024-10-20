using Mds.TddExample.Api.Common;
using Mds.TddExample.Domain.Domains.Helicopters.Models;

namespace Mds.TddExample.Api.Helicopters
{
    public class HelicopterDtoMapper : IDtoMapper<HelicopterModel, HelicopterDto>
    {
        public HelicopterDto MapFrom(HelicopterModel model)
        {
            return new HelicopterDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public HelicopterModel MapTo(HelicopterDto dto)
        {
            return new HelicopterModel(dto.Id, dto.Name);
        }
    }
}
