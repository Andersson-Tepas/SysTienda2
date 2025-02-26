using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string Dirección { get; set; } = null!;

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
}
