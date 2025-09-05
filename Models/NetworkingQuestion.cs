using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models;

public partial class NetworkingQuestion
{
    [Key]
    public long NetworkingQuestionsId { get; set; }

    public long EventId { get; set; }

    public string? Question { get; set; }

    public virtual NetworkingEvent Event { get; set; } = null!;
}
