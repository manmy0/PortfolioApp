using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class ContactsOfInterest
{
    public long ContactOfInterestId { get; set; }

    public string UserId { get; set; } = null!;

    public string ContactDetails { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
