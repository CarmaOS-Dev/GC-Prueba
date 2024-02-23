using System;
using System.Collections.Generic;

namespace Empresa_API.Models
{
    public partial class TEmpleado
    {
        public int IdNumEmp { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Edad { get; set; }
        public int Puesto { get; set; }
        public string Estatus { get; set; } = null!;

        public virtual TCatPuesto PuestoNavigation { get; set; } = null!;
    }
}
