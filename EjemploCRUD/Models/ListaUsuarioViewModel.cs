using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EjemploCRUD.Models
{
    public class ListaUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}