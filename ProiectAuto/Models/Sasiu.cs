//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProiectAuto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sasiu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sasiu()
        {
            this.Autoes = new HashSet<Auto>();
        }
    
        public int SasiuId { get; set; }
        public string CodSasiu { get; set; }
        public string Denumire { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auto> Autoes { get; set; }
    }
}
