﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Duration
{
    public int DurationId { get; set; }

    public string? DurationName { get; set; }

    public TimeOnly? Time { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<ServicePrice> ServicePrices { get; set; } = new List<ServicePrice>();
}
