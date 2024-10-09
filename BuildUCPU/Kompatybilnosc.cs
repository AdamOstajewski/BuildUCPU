using System;
using System.Collections.Generic;

namespace BuildUCPU;

public partial class Kompatybilnosc
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public virtual ICollection<Chlodzenie> Chlodzenies { get; set; } = new List<Chlodzenie>();

    public virtual ICollection<DyskiTwarde> DyskiTwardes { get; set; } = new List<DyskiTwarde>();

    public virtual ICollection<KartyGraficzne> KartyGraficznes { get; set; } = new List<KartyGraficzne>();

    public virtual ICollection<Obudowy> Obudowies { get; set; } = new List<Obudowy>();

    public virtual ICollection<PamieciRam> PamieciRams { get; set; } = new List<PamieciRam>();

    public virtual ICollection<PlytyGlowne> PlytyGlownes { get; set; } = new List<PlytyGlowne>();

    public virtual ICollection<Procesory> Procesories { get; set; } = new List<Procesory>();

    public virtual ICollection<Zasilacze> Zasilaczes { get; set; } = new List<Zasilacze>();
}
