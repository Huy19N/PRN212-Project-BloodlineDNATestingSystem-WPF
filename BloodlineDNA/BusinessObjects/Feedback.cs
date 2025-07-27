using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Feedback
{
    public int BookingId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Comment { get; set; }

    public int Rating { get; set; }

    public virtual Booking Booking { get; set; } = null!;
}
