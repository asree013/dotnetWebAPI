using System;
using System.Collections.Generic;

namespace dotnetFirstAPI.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public int Stock { get; set; }

    public decimal Price { get; set; }

    public DateTime Created { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
