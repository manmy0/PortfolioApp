using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class NetworkingQuestion
{
    public long NetworkingQuestionsId { get; set; }

    public string UserId { get; set; } = null!;

    public string? Question { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
