using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

[Table("Detalle_Factura")]
public partial class DetalleFactura
{
    [Key]
    [Column("IdDetalle_Factura")]
    public int IdDetalleFactura { get; set; }

    public int IdFactura { get; set; }

    public int IdServicio { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Precio { get; set; }

    [ForeignKey("IdFactura")]
    [InverseProperty("DetalleFactura")]
    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    [ForeignKey("IdServicio")]
    [InverseProperty("DetalleFactura")]
    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
