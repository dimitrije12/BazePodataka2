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
    
    public partial class Vlasnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vlasnik()
        {
            this.Drzis = new HashSet<Drzi>();
        }
    
        public string JMBG_V { get; set; }
        public string Ime_V { get; set; }
        public string Prezime_V { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drzi> Drzis { get; set; }
    }
}
