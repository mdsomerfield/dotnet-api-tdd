using Mds.TddExample.Db.Entities;
using Mds.TddExample.Domain.Common;

namespace Mds.TddExample.Domain.Domains.Helicopters.Models
{
    internal class HelicopterModelMapper : IModelMapper<Helicopter, HelicopterModel>
    {
        public HelicopterModel MapFrom(Helicopter entity)
        {
            return new HelicopterModel(entity.Id, entity.Name);
        }

        public Helicopter MapTo(HelicopterModel model)
        {
            return new Helicopter
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
