using System;
using System.Collections.Generic;

namespace Empresa_MVC.Models.DataBase
{
    public partial class CatPuesto
    {
        public CatPuesto()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdPuesto { get; set; }
        public string Puesto { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
