using System.Diagnostics;
using Day66WebSite.Models.Dtos;
using Newtonsoft.Json;

namespace Day66WebSite.Models.Services;

public interface ITestService
{
    Task<List<FlightDto>> Test1Async();
}

public class TestService :  ITestService
{
    private readonly HttpClient _httpClient;

    public TestService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FlightDto>> Test1Async()
    {
        Debug.Assert(_httpClient.BaseAddress != null);

        var uri = new Uri(_httpClient.BaseAddress, "/api/Flights");

        var responseText = await _httpClient.GetStringAsync(uri);

        var test1ResponseDto = JsonConvert.DeserializeObject<List<FlightDto>>(responseText);

        return test1ResponseDto;
    }

    public void Test2()
    {
        Debug.Assert(_httpClient.BaseAddress != null);

        var uri = new Uri(_httpClient.BaseAddress, "/api/Locations");

        //_httpClient.
    }

    public void Test3()
    {
        Debug.Assert(_httpClient.BaseAddress != null);

        var uri = new Uri(_httpClient.BaseAddress, "/api/Locations");

        //_httpClient.
    }
}
