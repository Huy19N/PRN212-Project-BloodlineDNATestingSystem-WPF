using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class VerifyEmail
{
    public string Key { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsResetPwd { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ExpiredAt { get; set; }
}
