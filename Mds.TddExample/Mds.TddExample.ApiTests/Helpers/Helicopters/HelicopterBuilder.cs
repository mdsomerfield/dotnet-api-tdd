using Mds.TddExample.Api.Inventory;

namespace Mds.TddExample.ApiTests.Helpers.Helicopters
{
    public class HelicopterBuilder
    {
        public HelicopterDto Instance { get; }

        public HelicopterBuilder()
        {
            Instance = new HelicopterDto();
        }

        public HelicopterBuilder WithName()
        {
            Instance.Name = "Name";
            return this;
        }

        public HelicopterDto Build()
        {
            throw new NotImplementedException();
        }

        public HelicopterBuilder Clone()
        {
            throw new NotImplementedException();
        }
    }
}
