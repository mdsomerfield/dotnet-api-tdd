using System.Net;
using System.Text;
using System.Text.Json;

namespace Mds.TddExample.ApiTests.TestFramework;

public class JsonClient
{
    private readonly HttpClient _client;

    public JsonClient(HttpClient client) => _client = client;

    public async Task<JsonResponse<TResponse>> GetAsync<TResponse>(string uri)
    {
        var response = await _client.GetAsync(uri);
        return await GetResponseBody<TResponse>(response);
    }

    public async Task<JsonResponse<TResponse>> PostAsync<TResponse>(string uri)
    {
        var response = await _client.PostAsync(uri, null);
        return await GetResponseBody<TResponse>(response);
    }

    public async Task<JsonResponse<TResponse>> PostAsync<TRequest, TResponse>(string uri, TRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(uri, content);
        return await GetResponseBody<TResponse>(response);
    }

    public async Task<JsonResponse<TResponse>> PostAsync<TResponse>(string uri, HttpContent content)
    {
        var response = await _client.PostAsync(uri, content);
        return await GetResponseBody<TResponse>(response);
    }

    public async Task<JsonResponse<TResponse>> PutAsync<TRequest, TResponse>(string uri, TRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync(uri, content);
        return await GetResponseBody<TResponse>(response);
    }

    public async Task DeleteAsync(string uri)
    {
        var response = await _client.DeleteAsync(uri);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Expected {HttpStatusCode.OK} but received {response.StatusCode}");
        }
    }
    private static async Task<JsonResponse<TResponse>> GetResponseBody<TResponse>(HttpResponseMessage response)
    {
        var contentString = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Expected {HttpStatusCode.OK} but received {response.StatusCode}")
            {
                Data = { { "ResponseBody", contentString } },
            };
        }

        var jsonBody = contentString is TResponse responseString
            ? responseString
            : JsonSerializer.Deserialize<TResponse>(contentString);

        return new JsonResponse<TResponse>
        {
            Body = jsonBody,
            Status = response.StatusCode
        };
    }
}

public class JsonResponse<T>
{
    public T? Body { get; set; }
    public HttpStatusCode Status { get; set; }
}
