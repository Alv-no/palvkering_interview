using Alv.Parkering.Application.Interfaces;
using Alv.Parkering.Domain.Models;
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
    public Task<List<ParkingSpot>> Get([FromQuery] int page = 0, [FromQuery] int pageSize = 25)
    {
        return parkingStore.FetchParkingSpots(page, pageSize);
    }
}
