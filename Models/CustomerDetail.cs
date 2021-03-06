//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Nullable<int> CustomerAge { get; set; }
        public string CustomerGender { get; set; }
        public int CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
    
        public virtual UserRole UserRole { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
    }
}
