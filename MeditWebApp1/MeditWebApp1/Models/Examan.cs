//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeditWebApp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Examan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Examan()
        {
            this.ExamenPratiques = new HashSet<ExamenPratique>();
            this.Risques = new HashSet<Risque>();
        }
    
        public decimal codeExamen { get; set; }
        public string description { get; set; }
        public Nullable<decimal> prixSoumis { get; set; }
        public Nullable<decimal> prixNonSoumis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamenPratique> ExamenPratiques { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Risque> Risques { get; set; }
    }
}
