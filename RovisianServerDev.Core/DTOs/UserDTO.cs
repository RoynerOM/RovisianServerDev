using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RovisianServerDev.Core.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Cedula { get; set; } = null!;
        public int TipoCedula { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Carnet { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasenna { get; set; } = null!;
        public string Firma { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? UtimaVez { get; set; }
        public Guid? RolId { get; set; }

    }
}
