using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class NetworkingEvent
{
    public long EventId { get; set; }

    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTimeOffset? Date { get; set; }

    public string? Location { get; set; }

    public string? Details { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
