using System;
using System.Collections.Generic;

namespace PropertyHubAPI.Models;

public partial class Property
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public decimal Price { get; set; }

    public string PropertyType { get; set; } = null!;

    public int? Bedrooms { get; set; }

    public decimal? Bathrooms { get; set; }

    public int SquareFootage { get; set; }

    public int? YearBuilt { get; set; }

    public string Status { get; set; } = null!;

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public DateTime DateListed { get; set; }

    public int AgentId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Agent Agent { get; set; } = null!;

    public virtual ICollection<Inquiry> Inquiries { get; set; } = new List<Inquiry>();

    public virtual ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
}
