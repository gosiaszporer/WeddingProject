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
    
    public partial class Szablon_uroczystości
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Szablon_uroczystości()
        {
            this.Weseles = new HashSet<Wesele>();
        }
    
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public decimal Szablon_uroczystości_ID { get; set; }
        public decimal Oferta_catering_Oferta_catering_ID { get; set; }
        public decimal Oferta_cukiernik_Oferta_cukiernik_ID { get; set; }
        public decimal Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID { get; set; }
    
        public virtual Oferta_catering Oferta_catering { get; set; }
        public virtual Oferta_cukiernik Oferta_cukiernik { get; set; }
        public virtual Oferta_kwiaciarnia Oferta_kwiaciarnia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wesele> Weseles { get; set; }
    }
}
