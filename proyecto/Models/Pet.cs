//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public int Id_Pets { get; set; }
        public string Pet_Name { get; set; }
        public string Birth_Date { get; set; }
        public Nullable<int> Id_Pet_Type { get; set; }
        public Nullable<int> Id_Owners { get; set; }
    
        public virtual Owner Owner { get; set; }
        public virtual Pet_Type Pet_Type { get; set; }
    }
}