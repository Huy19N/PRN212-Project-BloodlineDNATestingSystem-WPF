﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class ServicePrice
{
    public int ServicePriceId { get; set; }

    public int? ServiceId { get; set; }

    public int? DurationId { get; set; }

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Duration? Duration { get; set; }

    public virtual Service? Service { get; set; }
}
