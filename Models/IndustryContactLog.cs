using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models;

public partial class IndustryContactLog
{
    [Key]
    public long ContactId { get; set; }

    public string UserId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Company { get; set; }

    public string? Notes { get; set; }

    public DateOnly? DateMet { get; set; }

    public virtual ICollection<IndustryContactInfo> IndustryContactInfos { get; set; } = new List<IndustryContactInfo>();

    public virtual ApplicationUser User { get; set; } = null!;
}
