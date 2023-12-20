﻿using System;
using System.Collections.Generic;

namespace Sehaty.Models;

public partial class TenagaKesehatan
{
    public ushort Id { get; set; }

    public ushort? IdDiary { get; set; }

    public string Nama { get; set; } = null!;

    public DateOnly TanggalLahir { get; set; }

    public string JenisKelamin { get; set; } = null!;

    public ulong Telepon { get; set; }

    public string Email { get; set; } = null!;

    public uint NoStrF { get; set; }

    public uint NoStrL { get; set; }

    public string Spesialis { get; set; } = null!;

    public string TempatPraktik { get; set; } = null!;

    public virtual DiaryKesehatan? IdDiaryNavigation { get; set; }
}
