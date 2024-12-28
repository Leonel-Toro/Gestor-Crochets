using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gestor.Modelos;

namespace Gestor.Data
{
    public class GestorContext : DbContext
    {
        public GestorContext(DbContextOptions<GestorContext> options)
            : base(options)
        {
        }

        public DbSet<Gestor.Modelos.CostoMaterial> CostoMaterial { get; set; } = default!;
        public DbSet<Gestor.Modelos.Producto> Producto { get; set; } = default!;
        public DbSet<Gestor.Modelos.Patron> Patron { get; set; } = default!;
        public DbSet<Gestor.Modelos.Ingresos> Ingresos { get; set; } = default!;
        public DbSet<Gestor.Modelos.MaterialProducto> MaterialProducto { get; set; } = default!;

    }
}
