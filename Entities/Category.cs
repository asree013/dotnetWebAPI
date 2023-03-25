using System;
using System.Collections.Generic;

namespace dotnetFirstAPI.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
