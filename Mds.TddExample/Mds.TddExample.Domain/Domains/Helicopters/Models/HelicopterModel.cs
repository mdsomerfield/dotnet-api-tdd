using Mds.TddExample.Db.Entities;

namespace Mds.TddExample.Domain.Domains.Helicopters.Models
{
    public class HelicopterModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public HelicopterModel(Helicopter entry)
        {
            Id = entry.Id;
            Name = entry.Name;
        }

        public Helicopter ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
