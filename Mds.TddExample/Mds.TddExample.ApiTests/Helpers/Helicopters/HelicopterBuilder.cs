using Mds.TddExample.Api.Helicopters;

namespace Mds.TddExample.ApiTests.Helpers.Helicopters
{
    public class HelicopterBuilder
    {
        public HelicopterDto Instance { get; }

        public HelicopterBuilder()
        {
            Instance = new HelicopterDto();
        }

        public HelicopterBuilder WithName(string name)
        {
            Instance.Name = name;
            return this;
        }

        public HelicopterDto Build()
        {
            return Instance;
        }

        public HelicopterBuilder Clone()
        {
            return new HelicopterBuilder()
                .WithName(Instance.Name);
        }
    }
}
