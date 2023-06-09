using System;
using System.Collections.Generic;

namespace gps_test.Models;

public partial class location
{
    public int locationId { get; set; }

    public decimal locationLng { get; set; }

    public decimal locationLat { get; set; }

    public string locationName { get; set; } = null!;
}
