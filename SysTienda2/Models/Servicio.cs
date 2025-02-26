using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class Servicio
{
    [Key]
    public int IdServicio { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Descripción { get; set; } = null!;

    [InverseProperty("IdServicioNavigation")]
    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();
}
