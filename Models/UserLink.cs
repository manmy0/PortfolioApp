using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class UserLink
{
    public long LinkId { get; set; }

    public string UserId { get; set; } = null!;

    public string Link { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
