using Day66WebSite.Models.Dtos;
using Day66WebSite.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day66WebSite.Controllers;

public class LocationController : Controller
{
    private readonly ILocationService _locationService;
    private readonly ILogger<LocationController> _logger;

    public LocationController(ILocationService locationService, ILogger<LocationController> logger)
    {
        _locationService = locationService;
        _logger = logger;
    }

    public async Task<IActionResult> Search(int? id)
    {
        LocationDto? locationDto = null;

        if (id != null)
        {
            try
            {
                locationDto = await _locationService.GetByIdAsync((int)id);
            }
            catch (Exception e)
            {
                ViewData["ErrorMessage"] = $"Location Id {id} not found";
                _logger.LogError(e, "Error Getting Location By Id");
            }
        }

        return View(locationDto);
    }

    [HttpGet]
    public async Task<IActionResult> AddAsync()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(LocationDto locationDto)
    {
        try
        {
            await _locationService.AddAsync(locationDto);
            ViewData["SuccessMessage"] = "Location Added Successfully";
        }
        catch (LocationApiFailedException e)
        {
            ViewData["ErrorMessage"] = $"Error Adding Location for {locationDto.name}";
            _logger.LogError(e, $"We got a non-OK response from API. StatusCode = {e.ResponseStatusCode}");
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> DeleteAsync(int? id)
    {
        if (id == null)
        {
            ViewData["ErrorMessage"] = $"Location Id {id} missing in parameter";
            return View();
        }

        try
        {
            var locationDto = await _locationService.GetByIdAsync((int)id);
            return View(locationDto);
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"Location Id {id} not found";
            _logger.LogError(e, "Error Getting Location By Id");

            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteLocationAsync(int? id)
    {
        if (id == null)
        {
            ViewData["ErrorMessage"] = $"Location Id {id} missing in parameter";
            return View("Delete");
        }

        try
        {
            await _locationService.DeleteAsync((int)id);
            ViewData["SuccessMessage"] = "Location Deleted Successfully";
            return View("Delete");
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = $"Location Id {id} not found";
            _logger.LogError(e, "Error Getting Location By Id");

            return View("Delete");
        }
    }
}