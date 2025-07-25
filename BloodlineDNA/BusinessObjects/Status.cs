﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Status
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
