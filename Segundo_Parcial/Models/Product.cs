namespace Segundo_Parcial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{6}$", ErrorMessage = "El formato del número de factura no es válido.")]
        public string NumeroFactura { get; set; }

        public DateTime FechaHora { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal TotalIva5 { get; set; }

        [Required]
        public decimal TotalIva10 { get; set; }

        [Required]
        public decimal TotalIva { get; set; }

        [Required]
        [MinLength(6)]
        public string TotalLetras { get; set; }

        public string Sucursal { get; set; }
    }
}
