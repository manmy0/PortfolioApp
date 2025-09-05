using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models;

public partial class NetworkingEvent
{
    [Key]
    public long EventId { get; set; }

    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? Date { get; set; }

    public string? Location { get; set; }

    public string? Details { get; set; }

    public virtual ICollection<NetworkingQuestion> NetworkingQuestions { get; set; } = new List<NetworkingQuestion>();

    public virtual ApplicationUser User { get; set; } = null!;

}