//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GraduateThesisSystem.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TEnstitu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEnstitu()
        {
            this.TTez = new HashSet<TTez>();
        }
    
        public int EnstituID { get; set; }
        public string Enstitu { get; set; }
        public int Universite { get; set; }
    
        public virtual TUniversite TUniversite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTez> TTez { get; set; }
    }
}
