using System;
using System.Collections.Generic;

namespace net_core_template_2025.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
