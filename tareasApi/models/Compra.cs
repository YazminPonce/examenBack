using System;
using System.Collections.Generic;

namespace tareasApi.Models;

public partial class Compra
{
    public int CompraId { get; set; }

    public int ProductoId { get; set; }

    public DateTime FechaCompra { get; set; }
}
