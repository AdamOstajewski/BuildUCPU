using System;
using System.Collections.Generic;

namespace BuildUCPU;

public partial class Obudowy
{
    public int Nr { get; set; }

    public int? KompatybilnoscId { get; set; }

    public string Producent { get; set; } = null!;

    public string Model { get; set; } = null!;

    public decimal Cena { get; set; }

    public string Wydajnosc { get; set; } = null!;

    public string Kompatybilnosc { get; set; } = null!;

    public string Dostepnosc { get; set; } = null!;

    public string Gwarancja { get; set; } = null!;

    public string? DodatkoweFunkcje { get; set; }

    public virtual ICollection<GotoweZestawy> GotoweZestawies { get; set; } = new List<GotoweZestawy>();

    public virtual Kompatybilnosc? KompatybilnoscNavigation { get; set; }
}
