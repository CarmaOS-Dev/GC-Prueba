using System;
using System.Collections.Generic;

namespace Empresa_MVC.Models.DataBase
{
    public partial class TCatPuesto
    {
        public TCatPuesto()
        {
            TEmpleados = new HashSet<TEmpleado>();
        }

        public int IdPuesto { get; set; }
        public string Puesto { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<TEmpleado> TEmpleados { get; set; }
    }
}
