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
    
    public partial class PrivatnaSkola
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrivatnaSkola()
        {
            this.Pohadjas = new HashSet<Pohadja>();
            this.Zaposlenis = new HashSet<Zaposleni>();
            this.Kabineti = new HashSet<Kabinet>();
            this.Drzis = new HashSet<Drzi>();
        }
    
        public int RegBroj { get; set; }
        public string BrojTelefon { get; set; }
        public string ImeSkole { get; set; }
        public int GradPostanskiBroj { get; set; }
    
        public virtual Grad Grad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pohadja> Pohadjas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaposleni> Zaposlenis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kabinet> Kabineti { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Drzi> Drzis { get; set; }
    }
}
