//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirmaWebAPI.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Racun
    {
        public int ID { get; set; }
        public System.DateTime Datum { get; set; }
        public decimal Iznos { get; set; }
        public int FirmaID { get; set; }
    
        public virtual Firma Firma { get; set; }
    }
}