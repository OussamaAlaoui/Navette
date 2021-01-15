using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Navette.Models;

namespace Navette.DataContext
{
    public class NavetteDBContext : DbContext
    {
        public NavetteDBContext() : base(nameOrConnectionString: "Navette_Entities")
        {

        }
        public virtual DbSet<user> User { get; set; }
        public virtual DbSet<vehicule> Vehicule { get; set; }
        public virtual DbSet<line> Line { get; set; }
        public virtual DbSet<payment_methods> Payment_Method { get; set; }
        public virtual DbSet<subscription> Subsciption { get; set; }
        public virtual DbSet<paypal_accounts> Paypal { get; set; }
        public virtual DbSet<bank_cards> Bank_Card { get; set; }
        public virtual DbSet<bank_cards> Request { get; set; }
    }
}

