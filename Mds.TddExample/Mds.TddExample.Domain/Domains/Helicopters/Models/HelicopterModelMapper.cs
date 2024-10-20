using Mds.TddExample.Db.Entities;

namespace Mds.TddExample.Domain.Domains.Helicopters.Models
{
    public interface IHelicopterModelMapper
    {
        HelicopterModel MapFrom(Helicopter entity);

        Helicopter MapTo(HelicopterModel model);
    }

    internal class HelicopterModelMapper : IHelicopterModelMapper
    {
        public HelicopterModel MapFrom(Helicopter entity)
        {
            return new HelicopterModel(entity.Id, entity.Name);
        }

        public Helicopter MapTo(HelicopterModel model)
        {
            return new Helicopter
            {
                Id = (int)model.Id,
                Name = model.Name
            };
        }
    }
}
