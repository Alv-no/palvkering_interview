namespace Alv.Parkering.Host.Models;


public record ParkingSpotDto(string Address, int FreeParkingCount, int PaidParkingCount, int CharingSpotCount, int HandicapSpotCount, string HandicapDescription);
