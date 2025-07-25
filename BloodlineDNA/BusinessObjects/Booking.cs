﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public int? DurationId { get; set; }

    public int? ServiceId { get; set; }

    public int? MethodId { get; set; }

    public int? ResultId { get; set; }

    public int? StatusId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Duration? Duration { get; set; }

    public virtual CollectionMethod? Method { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual TestResult? Result { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Status? Status { get; set; }

    public virtual User? User { get; set; }
}
