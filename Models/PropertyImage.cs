using System;
using System.Collections.Generic;

namespace PropertyHubAPI.Models;

public partial class PropertyImage
{
    public int Id { get; set; }

    public int PropertyId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public bool IsPrimary { get; set; }

    public int SortOrder { get; set; }

    public virtual Property Property { get; set; } = null!;
}
