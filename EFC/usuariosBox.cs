//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFC
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuariosBox
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> UsuarioBloqueado { get; set; }
        public Nullable<int> IdSucursal { get; set; }
    
        public virtual sucursalesBox sucursalesBox { get; set; }
    }
}
