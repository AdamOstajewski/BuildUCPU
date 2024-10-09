using System;
using System.Collections.Generic;

namespace BuildUCPU;

public partial class GotoweZestawy
{
    public int Nr { get; set; }

    public string Sekcja { get; set; } = null!;

    public int? ChlodzenieId { get; set; }

    public int? DyskiTwardeId { get; set; }

    public int? KartyGraficzneId { get; set; }

    public int? ObudowyId { get; set; }

    public int? PamieciRamId { get; set; }

    public int? PlytyGlowneId { get; set; }

    public int? ProcesoryId { get; set; }

    public int? ZasilaczeId { get; set; }

    public virtual Chlodzenie? Chlodzenie { get; set; }

    public virtual DyskiTwarde? DyskiTwarde { get; set; }

    public virtual KartyGraficzne? KartyGraficzne { get; set; }

    public virtual Obudowy? Obudowy { get; set; }

    public virtual PamieciRam? PamieciRam { get; set; }

    public virtual PlytyGlowne? PlytyGlowne { get; set; }

    public virtual Procesory? Procesory { get; set; }

    public virtual Zasilacze? Zasilacze { get; set; }
}
