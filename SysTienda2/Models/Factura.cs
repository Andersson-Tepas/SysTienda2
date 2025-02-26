using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class Factura
{
    [Key]
    public int IdFactura { get; set; }

    public int IdCliente { get; set; }

    [Column("Fecha_Factura", TypeName = "datetime")]
    public DateTime FechaFactura { get; set; }

    [Column("Fecha_Vencimiento", TypeName = "datetime")]
    public DateTime FechaVencimiento { get; set; }

    [Column("SubTotal_sin_iva", TypeName = "decimal(6, 2)")]
    public decimal SubTotalSinIva { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Descuento { get; set; }

    [Column("IVA", TypeName = "decimal(6, 2)")]
    public decimal Iva { get; set; }

    [Column("Total_con_IVA", TypeName = "decimal(6, 2)")]
    public decimal TotalConIva { get; set; }

    [Column("Importe_pagado", TypeName = "decimal(6, 2)")]
    public decimal ImportePagado { get; set; }

    [Column("Importe_pagar", TypeName = "decimal(6, 2)")]
    public decimal ImportePagar { get; set; }

    [InverseProperty("IdFacturaNavigation")]
    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Factura")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
