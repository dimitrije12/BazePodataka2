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
    
    public partial class Predmet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Predmet()
        {
            this.Profesori = new HashSet<Profesor>();
        }
    
        public string ImePredmet { get; set; }
        public int BrojCasova { get; set; }
        public int KabinetBroj { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Profesor> Profesori { get; set; }
        public virtual Kabinet Kabinet { get; set; }
    }
}