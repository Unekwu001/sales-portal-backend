using System;
using System.Collections.Generic;

namespace Data.Models.CoverageModels;

public partial class GcpGeoCodingApiKey
{
    public Guid Id { get; set; }

    public string Key { get; set; } = null!;
}
