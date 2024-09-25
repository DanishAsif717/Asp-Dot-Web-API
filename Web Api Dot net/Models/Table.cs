using System;
using System.Collections.Generic;

namespace Web_Api_Dot_net.Models;

public partial class Table
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? RolNumber { get; set; }

    public string? Company { get; set; }
}
