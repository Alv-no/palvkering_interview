using Alv.Parkering.Application.Interfaces;
using Alv.Parkering.Domain.Models;
using Alv.Parkering.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Alv.Parkering.Infrastructure.Repositories;

public class ParkingSpotRepository : IParkingStore
{
    private readonly ParkeringContext context;

    public ParkingSpotRepository(ParkeringContext context)
    {
        this.context = context;
    }

    public Task<List<ParkingSpot>> FetchParkingSpots(int page, int pageSize)
    {
        return context.Parkeringers
            .Join(context.Detailjers, parkering => parkering.Id, detalj => detalj.Id, (parkering, detalj) => new ParkingSpot(
                parkering.Adresse ?? "",
                detalj.AntallAvgiftsbelagtePlasser ?? 0,
                detalj.AntallLadeplasser?? 0,
                detalj.AntallLadeplasser ?? 0,
                detalj.AntallForflytningshemmede ?? 0,
                detalj.VurderingForflytningshemmede ?? ""))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
