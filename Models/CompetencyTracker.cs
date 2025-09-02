using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class CompetencyTracker
{
    public string UserId { get; set; } = null!;

    public long CompetencyId { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string Level { get; set; } = null!;

    public string? SkillsReview { get; set; }

    public string? Evidence { get; set; }

    public DateTimeOffset Created { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    public virtual Competency Competency { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
