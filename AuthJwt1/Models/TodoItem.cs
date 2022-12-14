using System;
using System.Collections.Generic;

namespace AuthJwt1.Models;

public partial class TodoItem
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string Status { get; set; } = null!;
}
