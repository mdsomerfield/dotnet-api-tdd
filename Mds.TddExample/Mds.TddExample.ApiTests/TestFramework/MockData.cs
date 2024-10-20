using Bogus;

namespace Mds.TddExample.ApiTests.TestFramework
{
    public class MockData
    {
        public static Faker Faker { get; } = new Faker();
    }
}
