﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class DeliveryMethod
{
    public int DeliveryMethodId { get; set; }

    public string? DeliveryMethodName { get; set; }

    public virtual ICollection<Sample> Samples { get; set; } = new List<Sample>();
}
