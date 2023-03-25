using System;
using System.Collections.Generic;

namespace dotnetFirstAPI.Entities;

public partial class Account
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Created { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}
