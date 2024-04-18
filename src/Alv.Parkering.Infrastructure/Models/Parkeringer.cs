using System;
using System.Collections.Generic;

namespace Alv.Parkering.Infrastructure.Models;

public partial class Parkeringer
{
    public int Id { get; set; }

    public string? ParkeringstilbyderNavn { get; set; }

    public double? Breddegrad { get; set; }

    public double? Lengdegrad { get; set; }

    public string? Deaktivert { get; set; }

    public int? Versjonsnummer { get; set; }

    public string? Navn { get; set; }

    public string? Adresse { get; set; }

    public string? Postnummer { get; set; }

    public string? Poststed { get; set; }

    public string? Aktiveringstidspunkt { get; set; }

    public virtual Detailjer? Detailjer { get; set; }
}
