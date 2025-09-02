using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class Goal
{
    public long GoalId { get; set; }

    public string UserId { get; set; } = null!;

    public DateOnly DateSet { get; set; }

    public string Description { get; set; } = null!;

    public string? Timeline { get; set; }

    public string? Progress { get; set; }

    public string? Learnings { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool Complete { get; set; }

    public string? CompletionNotes { get; set; }

    public virtual ICollection<GoalStep> GoalSteps { get; set; } = new List<GoalStep>();

    public virtual AspNetUser User { get; set; } = null!;
}
