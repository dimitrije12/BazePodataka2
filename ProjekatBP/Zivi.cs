//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjekatBP
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zivi
    {
        public int GradPostanskiBroj { get; set; }
        public string UcenikJMBG_U { get; set; }
    
        public virtual Grad Grad { get; set; }
        public virtual Ucenik Ucenik { get; set; }
    }
}
