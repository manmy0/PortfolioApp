using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class Networking
{
    public string UserId { get; set; } = null!;

    public string? ElevatorPitch { get; set; }

    public long NetworkingId { get; set; }

    public DateOnly LastUpdated { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
