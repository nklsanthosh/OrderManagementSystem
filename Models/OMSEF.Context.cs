﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OMSEF : DbContext
    {
        public OMSEF()
            : base("name=OMSEF")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderMaster> OrderMasters { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Table_1> Table_1 { get; set; }
    
        public virtual ObjectResult<CustomerDetail> CreateCustomer(string customerName, Nullable<int> customerAge, string customerGender, Nullable<int> customerPhone, string customerEmail, string password, Nullable<int> userRoleId)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("customerName", customerName) :
                new ObjectParameter("customerName", typeof(string));
    
            var customerAgeParameter = customerAge.HasValue ?
                new ObjectParameter("CustomerAge", customerAge) :
                new ObjectParameter("CustomerAge", typeof(int));
    
            var customerGenderParameter = customerGender != null ?
                new ObjectParameter("CustomerGender", customerGender) :
                new ObjectParameter("CustomerGender", typeof(string));
    
            var customerPhoneParameter = customerPhone.HasValue ?
                new ObjectParameter("CustomerPhone", customerPhone) :
                new ObjectParameter("CustomerPhone", typeof(int));
    
            var customerEmailParameter = customerEmail != null ?
                new ObjectParameter("CustomerEmail", customerEmail) :
                new ObjectParameter("CustomerEmail", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var userRoleIdParameter = userRoleId.HasValue ?
                new ObjectParameter("UserRoleId", userRoleId) :
                new ObjectParameter("UserRoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustomerDetail>("CreateCustomer", customerNameParameter, customerAgeParameter, customerGenderParameter, customerPhoneParameter, customerEmailParameter, passwordParameter, userRoleIdParameter);
        }
    
        public virtual ObjectResult<CustomerDetail> CreateCustomer(string customerName, Nullable<int> customerAge, string customerGender, Nullable<int> customerPhone, string customerEmail, string password, Nullable<int> userRoleId, MergeOption mergeOption)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("customerName", customerName) :
                new ObjectParameter("customerName", typeof(string));
    
            var customerAgeParameter = customerAge.HasValue ?
                new ObjectParameter("CustomerAge", customerAge) :
                new ObjectParameter("CustomerAge", typeof(int));
    
            var customerGenderParameter = customerGender != null ?
                new ObjectParameter("CustomerGender", customerGender) :
                new ObjectParameter("CustomerGender", typeof(string));
    
            var customerPhoneParameter = customerPhone.HasValue ?
                new ObjectParameter("CustomerPhone", customerPhone) :
                new ObjectParameter("CustomerPhone", typeof(int));
    
            var customerEmailParameter = customerEmail != null ?
                new ObjectParameter("CustomerEmail", customerEmail) :
                new ObjectParameter("CustomerEmail", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var userRoleIdParameter = userRoleId.HasValue ?
                new ObjectParameter("UserRoleId", userRoleId) :
                new ObjectParameter("UserRoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustomerDetail>("CreateCustomer", mergeOption, customerNameParameter, customerAgeParameter, customerGenderParameter, customerPhoneParameter, customerEmailParameter, passwordParameter, userRoleIdParameter);
        }
    
        public virtual int CreateCustomer1(string customerName, Nullable<int> customerAge, string customerGender, Nullable<int> customerPhone, string customerEmail, string password, Nullable<int> userRoleId)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("customerName", customerName) :
                new ObjectParameter("customerName", typeof(string));
    
            var customerAgeParameter = customerAge.HasValue ?
                new ObjectParameter("CustomerAge", customerAge) :
                new ObjectParameter("CustomerAge", typeof(int));
    
            var customerGenderParameter = customerGender != null ?
                new ObjectParameter("CustomerGender", customerGender) :
                new ObjectParameter("CustomerGender", typeof(string));
    
            var customerPhoneParameter = customerPhone.HasValue ?
                new ObjectParameter("CustomerPhone", customerPhone) :
                new ObjectParameter("CustomerPhone", typeof(int));
    
            var customerEmailParameter = customerEmail != null ?
                new ObjectParameter("CustomerEmail", customerEmail) :
                new ObjectParameter("CustomerEmail", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var userRoleIdParameter = userRoleId.HasValue ?
                new ObjectParameter("UserRoleId", userRoleId) :
                new ObjectParameter("UserRoleId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateCustomer1", customerNameParameter, customerAgeParameter, customerGenderParameter, customerPhoneParameter, customerEmailParameter, passwordParameter, userRoleIdParameter);
        }
    
        public virtual int createorder(Nullable<System.DateTime> orderDate, Nullable<int> addressId, Nullable<decimal> total_Amount, ObjectParameter orderMasterId)
        {
            var orderDateParameter = orderDate.HasValue ?
                new ObjectParameter("OrderDate", orderDate) :
                new ObjectParameter("OrderDate", typeof(System.DateTime));
    
            var addressIdParameter = addressId.HasValue ?
                new ObjectParameter("AddressId", addressId) :
                new ObjectParameter("AddressId", typeof(int));
    
            var total_AmountParameter = total_Amount.HasValue ?
                new ObjectParameter("Total_Amount", total_Amount) :
                new ObjectParameter("Total_Amount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createorder", orderDateParameter, addressIdParameter, total_AmountParameter, orderMasterId);
        }
    
        public virtual int createorderdetail(Nullable<int> orderMasterId, Nullable<int> productId, Nullable<int> quantity, Nullable<decimal> price)
        {
            var orderMasterIdParameter = orderMasterId.HasValue ?
                new ObjectParameter("OrderMasterId", orderMasterId) :
                new ObjectParameter("OrderMasterId", typeof(int));
    
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("ProductId", productId) :
                new ObjectParameter("ProductId", typeof(int));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createorderdetail", orderMasterIdParameter, productIdParameter, quantityParameter, priceParameter);
        }
    }
}