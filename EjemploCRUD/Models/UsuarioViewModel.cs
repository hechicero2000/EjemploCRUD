using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EjemploCRUD.Models
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Constraseña")]
        public string Contrasena { get; set; }
    }
}