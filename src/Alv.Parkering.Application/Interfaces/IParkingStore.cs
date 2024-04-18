using Alv.Parkering.Domain.Models;

namespace Alv.Parkering.Application.Interfaces;

public interface IParkingStore {
    Task<List<ParkingSpot>> FetchParkingSpots(int page, int pageSize);
}
