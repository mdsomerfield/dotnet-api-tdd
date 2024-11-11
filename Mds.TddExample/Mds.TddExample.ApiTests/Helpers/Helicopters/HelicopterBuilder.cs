using Bogus;
using FluentAssertions;
using Mds.TddExample.Api.Domains.Helicopters;
using Mds.TddExample.ApiTests.TestFramework;

namespace Mds.TddExample.ApiTests.Helpers.Helicopters
{
    public class HelicopterBuilder
    {
        public HelicopterDto Instance { get; }

        public HelicopterBuilder()
        {
            Instance = new HelicopterDto
            {
                Name = MockData.Faker.Vehicle.Model()
            };
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

        public void ShouldMatch(HelicopterDto helicopter)
        {
            helicopter.Name.Should().Be(Instance.Name);
        }
    }
}
