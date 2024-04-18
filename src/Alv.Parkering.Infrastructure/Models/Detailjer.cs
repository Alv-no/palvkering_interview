using System;
using System.Collections.Generic;

namespace Alv.Parkering.Infrastructure.Models;

public partial class Detailjer
{
    public int Id { get; set; }

    public string? Navn { get; set; }

    public string? Referanse { get; set; }

    public string? Adresse { get; set; }

    public string? Postnummer { get; set; }

    public string? Poststed { get; set; }

    public int? AntallAvgiftsbelagtePlasser { get; set; }

    public int? AntallAvgiftsfriePlasser { get; set; }

    public int? AntallLadeplasser { get; set; }

    public int? AntallForflytningshemmede { get; set; }

    public string? VurderingForflytningshemmede { get; set; }

    public string? Aktiveringstidspunkt { get; set; }

    public string? SistEndret { get; set; }

    public int? SkiltplanId { get; set; }

    public int? Versjonsnummer { get; set; }

    public string? Sluttidspunkt { get; set; }

    public int? OpplastetVurderingId { get; set; }

    public string? TypeParkeringsomrade { get; set; }

    public string? Innfartsparkering { get; set; }

    public virtual Parkeringer IdNavigation { get; set; } = null!;
}
