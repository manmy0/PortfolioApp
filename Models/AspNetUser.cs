using System;
using System.Collections.Generic;

namespace PortfolioApp.Models;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string? Certificates { get; set; }

    public string? CoverLetter { get; set; }

    public string? Degree { get; set; }

    public string? LinkedIn { get; set; }

    public string? Pitch { get; set; }

    public string? Resume { get; set; }

    public string? Specialisation { get; set; }

    public string? FirstName { get; set; }

    public string? Introduction { get; set; }

    public string? LastName { get; set; }

    public byte[]? ProfileImage { get; set; }

    public virtual ICollection<CareerDevelopmentPlan> CareerDevelopmentPlans { get; set; } = new List<CareerDevelopmentPlan>();

    public virtual ICollection<CompetencyTracker> CompetencyTrackers { get; set; } = new List<CompetencyTracker>();

    public virtual ICollection<ContactsOfInterest> ContactsOfInterests { get; set; } = new List<ContactsOfInterest>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<IndustryContactLog> IndustryContactLogs { get; set; } = new List<IndustryContactLog>();

    public virtual ICollection<NetworkingEvent> NetworkingEvents { get; set; } = new List<NetworkingEvent>();

    public virtual ICollection<UserLink> UserLinks { get; set; } = new List<UserLink>();
}
