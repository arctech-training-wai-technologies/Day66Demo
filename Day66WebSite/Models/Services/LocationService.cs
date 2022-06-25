using System.Net;
using System.Text;
using Day66WebSite.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Day66WebSite.Models.Services;

public interface ILocationService
{
    Task<LocationDto?> GetByIdAsync(int id);
    Task AddAsync(LocationDto locationDto);
    Task DeleteAsync(int id);
}

public class LocationService : ILocationService
{
    private readonly HttpClient _httpClient;

    public LocationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LocationDto?> GetByIdAsync(int id)
    {
        var uri = new Uri($"https://localhost:7081/api/Locations/{id}");

        /*
        var locationText = await _httpClient.GetStringAsync(uri);
        var locationDto = JsonConvert.DeserializeObject<LocationDto>(locationText);
        */

        var locationDto = await _httpClient.GetFromJsonAsync<LocationDto>(uri);

        return locationDto;
    }

    public async Task AddAsync(LocationDto locationDto)
    {
        var uri = new Uri($"https://localhost:7081/api/Locations");

        var locationJsonText = JsonConvert.SerializeObject(locationDto);
        var content = new StringContent(locationJsonText, Encoding.UTF8, "application/json");

        var  response = await _httpClient.PostAsync(uri, content);

        if (response.StatusCode != HttpStatusCode.Created)
            throw new LocationApiFailedException(response.StatusCode);
    }


    public async Task DeleteAsync(int id)
    {
        var uri = new Uri($"https://localhost:7081/api/Locations/{id}");

        var response = await _httpClient.DeleteAsync(uri);

        if (response.StatusCode != HttpStatusCode.NoContent)
            throw new LocationApiFailedException(response.StatusCode);
    }
}

class LocationApiFailedException : Exception
{
    public HttpStatusCode ResponseStatusCode { get; }

    public LocationApiFailedException(HttpStatusCode responseStatusCode)
    {
        ResponseStatusCode = responseStatusCode;
    }
}