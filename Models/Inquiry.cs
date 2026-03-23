using System;
using System.Collections.Generic;

namespace PropertyHubAPI.Models;

public partial class Inquiry
{
    public int Id { get; set; }

    public int PropertyId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Message { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Property Property { get; set; } = null!;
}
