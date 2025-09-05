using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models;

public partial class Cdl
{
    [Key]
    public int CdlId { get; set; }

    public DateTime DateCreated { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Link { get; set; }

    public DateTime LastUpdated { get; set; }

}
