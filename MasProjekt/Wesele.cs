//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasProjekt
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wesele
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wesele()
        {
            this.Umowas = new HashSet<Umowa>();
        }
    
        public string Nazwa { get; set; }
        public int Ilosc_gosci { get; set; }
        public System.DateTime Data_wesela { get; set; }
        public decimal Wesele_ID { get; set; }
        public decimal Konsultant_Osoba_Osoba_ID { get; set; }
        public decimal Szablon_uroczystości_Szablon_uroczystości_ID { get; set; }
        public decimal Lokalizacja_Lokalizacja_ID { get; set; }
    
        public virtual Konsultant Konsultant { get; set; }
        public virtual Lokalizacja Lokalizacja { get; set; }
        public virtual Szablon_uroczystości Szablon_uroczystości { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Umowa> Umowas { get; set; }
    }
}
