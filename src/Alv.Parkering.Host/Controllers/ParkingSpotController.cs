using Alv.Parkering.Application.Interfaces;
using Alv.Parkering.Host.Extensions;
using Alv.Parkering.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace Vite_CSharp.Controllers;

[ApiController]
[Route("[controller]")]
public class ParkingSpotController : ControllerBase
{
    private readonly ILogger<ParkingSpotController> logger;
    private readonly IParkingStore parkingStore;

    public ParkingSpotController(ILogger<ParkingSpotController> logger, IParkingStore parkingStore)
    {
        this.logger = logger;
        this.parkingStore = parkingStore;
    }

    [HttpGet]
    public async Task<IEnumerable<ParkingSpotDto>> Get(
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25
    )
    {
        var parkingSpots = await parkingStore.FetchParkingSpots(page, pageSize);
        return parkingSpots.Select(parkingSpot => parkingSpot.ToParkingSpotDto());
    }

    [HttpGet("all")]
    public async Task<IEnumerable<ParkingSpotDto>> GetAll()
    {
        var parkingSpots = await parkingStore.FetchAllParkingSpots();
        return parkingSpots.Select(parkingSpot => parkingSpot.ToParkingSpotDto());
    }
}
