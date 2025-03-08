using System;
using System.Collections.Generic;

namespace net_core_template_2025.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
