//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantReserv.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menu
    {
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Menu1 { get; set; }
        public string Details { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Picture { get; set; }
    
        public virtual MenuCategory MenuCategory { get; set; }
    }
}
