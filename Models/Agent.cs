using System;
using System.Collections.Generic;

namespace PropertyHubAPI.Models;

public partial class Agent
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Bio { get; set; }

    public string? LicenseNumber { get; set; }

    public string? ProfileImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
}
