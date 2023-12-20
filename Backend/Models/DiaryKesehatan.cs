using System;
using System.Collections.Generic;

namespace Sehaty.Models;

public partial class DiaryKesehatan
{
    public ushort Id { get; set; }

    public decimal? BeratBadan { get; set; }

    public decimal? Tinggi { get; set; }

    public decimal? GulaDarah { get; set; }

    public decimal? Systolic { get; set; }

    public decimal? Diastolic { get; set; }

    public decimal? Kolesterol { get; set; }

    public string? NamaObat { get; set; }

    public string? Keterangan { get; set; }

    public TimeOnly? Waktu { get; set; }

    public virtual ICollection<TenagaKesehatan> TenagaKesehatans { get; } = new List<TenagaKesehatan>();

    public virtual ICollection<Umum> Umums { get; } = new List<Umum>();
}
