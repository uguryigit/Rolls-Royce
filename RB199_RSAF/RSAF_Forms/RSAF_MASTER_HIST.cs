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
    
    public partial class RSAF_MASTER_HIST
    {
        public System.DateTime CREATE_DATE { get; set; }
        public System.DateTime UPDATE_DATE { get; set; }
        public bool STATUS { get; set; }
        public long MASTER_ID { get; set; }
        public string BAEPO { get; set; }
        public string BAEPART { get; set; }
        public string SITE { get; set; }
        public string TYPE { get; set; }
        public string MDR { get; set; }
        public string DESCRIPTION { get; set; }
        public string ROID_NO { get; set; }
    
        public virtual RSAF_MASTER RSAF_MASTER { get; set; }
    }
}
