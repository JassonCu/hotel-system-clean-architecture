using System;
using System.Collections.Generic;

namespace Hotel.Domian.Entities;

public partial class SystemConfig
{
    public int ConfigId { get; set; }

    public string ConfigName { get; set; } = null!;

    public string ConfigValue { get; set; } = null!;
}
