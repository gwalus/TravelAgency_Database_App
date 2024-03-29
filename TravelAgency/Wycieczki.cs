//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wycieczki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wycieczki()
        {
            this.Atrakcje = new HashSet<Atrakcje>();
            this.Usługi = new HashSet<Usługi>();
            this.Zamówienia = new HashSet<Zamówienia>();
            this.Hotele = new HashSet<Hotele>();
        }
    
        public int Id_wycieczki { get; set; }
        public Nullable<int> Id_rezydenta { get; set; }
        public string Kraj { get; set; }
        public Nullable<decimal> Cena_za_osobe { get; set; }
        public Nullable<int> Ilość_dostępnych_miejsc { get; set; }
        public Nullable<int> Ilość_miejsc { get; set; }
        public Nullable<System.DateTime> Data_wyjazdu { get; set; }
        public Nullable<System.DateTime> Data_powrotu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Atrakcje> Atrakcje { get; set; }
        public virtual Rezydenci Rezydenci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usługi> Usługi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zamówienia> Zamówienia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hotele> Hotele { get; set; }
    }
}
