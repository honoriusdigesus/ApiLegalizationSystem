using System;
using System.Collections.Generic;

namespace ApiLegalizationSystem.Data.Models;

public partial class User
{
    public int UserId { get; set; }

    public int IdentityDocument { get; set; }

    public string FullName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;
}
