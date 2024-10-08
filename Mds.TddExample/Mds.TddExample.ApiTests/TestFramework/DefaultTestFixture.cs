namespace Mds.TddExample.ApiTests.TestFramework
{
    public abstract class DefaultTestFixture
    {
        public ApiTestFixture Fixture { get; }

        public DefaultTestFixture(ApiTestFixture fixture)
        {
            Fixture = fixture;
        }

    }
}
