namespace Segundo_Parcial.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Nombre { get; set; }

        [Required]
        [MinLength(3)]
        public string Apellido { get; set; }

        [Required]
        [MinLength(3)]
        public string Documento { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El teléfono debe ser numérico y tener 10 dígitos")]
        public string Telefono { get; set; }

        public string Estado { get; set; }
    }
}
