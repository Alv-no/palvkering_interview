namespace Alv.Parkering.Domain.Models;

public record ParkingSpot(string Address, int FreeParkingCount, int PaidParkingCount, int CharingSpotCount, int HandicapSpotCount, string HandicapDescription);
