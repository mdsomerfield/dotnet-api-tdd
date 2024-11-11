using Mds.TddExample.Domain.Domains.Helicopters.Models;

namespace Mds.TddExample.Api.Domains.Helicopters
{
    public interface IHelicopterDtoMapper
    {

        HelicopterDto MapFrom(HelicopterModel model);
        HelicopterModel MapTo(HelicopterDto dto);
        HelicopterModel MapFrom(CreateHelicopterDto model);

    }

    public class HelicopterDtoMapper : IHelicopterDtoMapper
    {
        public HelicopterDto MapFrom(HelicopterModel model)
        {
            return new HelicopterDto
            {
                Id = (int)model.Id,
                Name = model.Name
            };
        }

        public HelicopterModel MapTo(HelicopterDto dto)
        {
            return new HelicopterModel(dto.Id, dto.Name);
        }

        public HelicopterModel MapFrom(CreateHelicopterDto model)
        {
            return new HelicopterModel(model.Name);
        }
    }
}
