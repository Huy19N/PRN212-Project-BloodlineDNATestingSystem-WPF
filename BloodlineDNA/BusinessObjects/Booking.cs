using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? UserId { get; set; }

    public int? ServicePriceId { get; set; }

    public int? MethodId { get; set; }

    public DateTime? AppointmentTime { get; set; }

    public int? StatusId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual CollectionMethod? Method { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ServicePrice? ServicePrice { get; set; }

    public virtual Status? Status { get; set; }

    public virtual TestResult? TestResult { get; set; }

    public virtual User? User { get; set; }
}
