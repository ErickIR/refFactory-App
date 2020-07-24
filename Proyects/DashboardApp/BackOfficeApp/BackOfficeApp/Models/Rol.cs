using System;
using System.Collections.Generic;

namespace BackOfficeApp.Models
{
    public partial class Rol
    {
        public Rol()
        {
            IntegranteJdV = new HashSet<IntegranteJdV>();
        }

        public int RolId { get; set; }
        public string Descripccion { get; set; }

        public virtual ICollection<IntegranteJdV> IntegranteJdV { get; set; }
    }
}
