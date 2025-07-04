﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Sample
{
    public int SampleId { get; set; }

    public int? BookingId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? Date { get; set; }

    public string? SampleVariant { get; set; }

    public int? CollectBy { get; set; }

    public int? DeliveryMethodId { get; set; }

    public string? Status { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual User? CollectByNavigation { get; set; }

    public virtual DeliveryMethod? DeliveryMethod { get; set; }

    public virtual Patient? Patient { get; set; }
}
