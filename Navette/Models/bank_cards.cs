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
    
    public partial class bank_cards
    {
        public int id { get; set; }
        public int owner_id { get; set; }
        public string account_number { get; set; }
        public string last_digits { get; set; }
        public string account_owner { get; set; }
        public Nullable<System.DateTime> expiration_date { get; set; }
    
        public virtual payment_methods payment_methods { get; set; }
    }
}
