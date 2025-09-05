using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models;

public partial class GoalStep
{
    [Key]
    public long StepId { get; set; }

    public long GoalId { get; set; }

    public string Step { get; set; } = null!;

    public virtual Goal Goal { get; set; } = null!;
}
