//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RSAF_Forms
{
    using System;
    using System.Collections.Generic;
    
    public partial class RSAF_SITE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RSAF_SITE()
        {
            this.RSAF_MASTER = new HashSet<RSAF_MASTER>();
        }
    
        public string SITE_CODE { get; set; }
        public string SITE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RSAF_MASTER> RSAF_MASTER { get; set; }
    }
}
