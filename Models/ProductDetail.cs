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
    
    public partial class ProductDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDetail()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Table_1 = new HashSet<Table_1>();
        }
    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public byte[] Image { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table_1> Table_1 { get; set; }
    }
}