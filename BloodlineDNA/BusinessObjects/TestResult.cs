﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class TestResult
{
    public int BookingId { get; set; }

    public DateTime? Date { get; set; }

    public string? ResultSummary { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
