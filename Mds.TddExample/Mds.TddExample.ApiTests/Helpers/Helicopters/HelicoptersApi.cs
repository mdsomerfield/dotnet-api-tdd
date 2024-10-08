using System.Runtime.InteropServices;
using Mds.TddExample.Api.Inventory;
using Mds.TddExample.ApiTests.TestFramework;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace Mds.TddExample.ApiTests.Helpers.Helicopters
{
    public class HelicoptersApi
    {
        private readonly JsonClient _jsonClient;

        public HelicoptersApi(ApiTestFixture fixture)
        {
            _jsonClient = fixture.CreateClient();
        }

        public async Task<IList<HelicopterDto>> GetAllHelicopters()
        {
            var response = await _jsonClient.GetAsync<IList<HelicopterDto>>("helicopters");
            return response.Body;
        }

        public async Task<HelicopterDto> CreateHelicopter(HelicopterDto createModel)
        {
            var response = await _jsonClient.PostAsync<HelicopterDto, HelicopterDto>("helicopters", createModel);
            return response.Body;
        }

        public async Task<HelicopterDto> GetHelicopter(int resourceId)
        {
            var response = await _jsonClient.GetAsync<HelicopterDto>($"helicopters/{resourceId}");
            return response.Body;
        }

        public async Task<HelicopterDto> UpdateHelicopter(int resourceId, HelicopterDto updateModel)
        {
            var response = await _jsonClient.PutAsync<HelicopterDto, HelicopterDto>($"helicopters/{resourceId}", updateModel);
            return response.Body;
        }

        public async Task DeleteHelicopter(int resourceId)
        {
            await _jsonClient.DeleteAsync($"helicopters/{resourceId}");
        }
    }
}
