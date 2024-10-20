using Mds.TddExample.Db.Entities;

namespace Mds.TddExample.Domain.Domains.Helicopters.Models
{
    public class HelicopterModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public HelicopterModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
