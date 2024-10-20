namespace Mds.TddExample.Domain.Domains.Helicopters.Models
{
    public class HelicopterModel
    {
        public int? Id { get; private set; }
        public string Name { get; private set; }

        public HelicopterModel(string name)
        {
            Name = name;
        }

        public HelicopterModel(int id, string name) : this(name)
        {
            Id = id;
        }
    }
}
