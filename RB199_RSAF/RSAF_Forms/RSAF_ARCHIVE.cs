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
    
    public partial class RSAF_ARCHIVE
    {
        public long DETAIL_ID { get; set; }
        public long X { get; set; }
        public string RECDOC { get; set; }
        public string DESPPART { get; set; }
        public string RVREF { get; set; }
        public string ANSPSI { get; set; }
        public string ANSRVREF { get; set; }
        public string SCRPREF { get; set; }
        public Nullable<System.DateTime> DESPARDT { get; set; }
        public Nullable<System.DateTime> RECDPART { get; set; }
        public Nullable<System.DateTime> INTOROS { get; set; }
        public Nullable<System.DateTime> ANSPSIDT { get; set; }
        public string REF { get; set; }
        public Nullable<System.DateTime> PROMDATE { get; set; }
        public Nullable<decimal> RCD { get; set; }
        public Nullable<decimal> ACC_DM { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<System.DateTime> PREVIOUS_PROMISE_DATE { get; set; }
    
        public virtual RSAF_DETAIL RSAF_DETAIL { get; set; }
    }
}