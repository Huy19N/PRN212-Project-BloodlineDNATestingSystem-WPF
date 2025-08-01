﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Patient
{
    public int PatientId { get; set; }

    public int BookingId { get; set; }

    public int? SampleId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string? IdentifyId { get; set; }

    public virtual Booking Booking { get; set; } = null!;

    public virtual Sample? Sample { get; set; }
}
