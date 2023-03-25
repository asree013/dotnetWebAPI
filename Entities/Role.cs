using System;
using System.Collections.Generic;

namespace dotnetFirstAPI.Entities;

public partial class Role
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Created { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
