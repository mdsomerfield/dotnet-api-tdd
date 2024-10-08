using Mds.TddExample.Db.Entities;
using Mds.TddExample.Domain.Domains.Helicopters.Models;

namespace Mds.TddExample.Api.Inventory
{
    public class HelicopterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static HelicopterDto MapFrom(HelicopterModel entity)
        {
            return new HelicopterDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static HelicopterModel MapToHelicopterModel()
        {
            throw new NotImplementedException();
        }
    }
}
