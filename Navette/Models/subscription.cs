//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Navette.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class subscription
    {
        public int traveller_id { get; set; }
        public int line_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> reduction { get; set; }
    
        public virtual line line { get; set; }
        public virtual traveller traveller { get; set; }
    }
}
