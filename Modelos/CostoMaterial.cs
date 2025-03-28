﻿using System.ComponentModel.DataAnnotations;
using NuGet.Packaging.Signing;

namespace Gestor.Modelos
{
    public class CostoMaterial
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El lugar de compra es obligatorio.")]
        [Display(Name = "Lugar de compra")]
        public string Lugar { get; set; }

        [Required(ErrorMessage = "El material es obligatorio.")]
        public string Material { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "El costo de compra es obligatorio.")]
        public double Costo { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria.")]
        public string Marca { get; set; }
        public Boolean eliminado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }

    }
}
