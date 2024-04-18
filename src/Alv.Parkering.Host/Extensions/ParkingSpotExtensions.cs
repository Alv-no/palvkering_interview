using Alv.Parkering.Domain.Models;
using Alv.Parkering.Host.Models;

namespace Alv.Parkering.Host.Extensions;

internal static class ParkingSpotExtensions {
    internal static ParkingSpotDto ToParkingSpotDto(this ParkingSpot parkingSpot) {
        return new ParkingSpotDto(parkingSpot.Address, parkingSpot.FreeParkingCount, parkingSpot.PaidParkingCount, parkingSpot.CharingSpotCount, parkingSpot.HandicapSpotCount, parkingSpot.HandicapDescription);
    }
}
