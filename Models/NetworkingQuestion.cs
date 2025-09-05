using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class NetworkingQuestion
{
    public long NetworkingQuestionsId { get; set; }

    public long EventId { get; set; }

    public string? Question { get; set; }

    public virtual NetworkingEvent Event { get; set; } = null!;
}
