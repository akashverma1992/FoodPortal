﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodPortal_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FoodOrderingConnStr : DbContext
    {
        public FoodOrderingConnStr()
            : base("name=FoodOrderingConnStr")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
    
        public virtual int deleteProducts(Nullable<int> productId)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("productId", productId) :
                new ObjectParameter("productId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteProducts", productIdParameter);
        }
    
        public virtual int deleteVendors(string vendorId)
        {
            var vendorIdParameter = vendorId != null ?
                new ObjectParameter("vendorId", vendorId) :
                new ObjectParameter("vendorId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteVendors", vendorIdParameter);
        }
    
        public virtual int upsertClients(string clientId, string password, string name, string email, string address, string contact)
        {
            var clientIdParameter = clientId != null ?
                new ObjectParameter("clientId", clientId) :
                new ObjectParameter("clientId", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var contactParameter = contact != null ?
                new ObjectParameter("contact", contact) :
                new ObjectParameter("contact", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("upsertClients", clientIdParameter, passwordParameter, nameParameter, emailParameter, addressParameter, contactParameter);
        }
    
        public virtual int upsertProducts(Nullable<int> productId, string name, string category, Nullable<float> price, Nullable<bool> offer)
        {
            var productIdParameter = productId.HasValue ?
                new ObjectParameter("productId", productId) :
                new ObjectParameter("productId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(float));
    
            var offerParameter = offer.HasValue ?
                new ObjectParameter("offer", offer) :
                new ObjectParameter("offer", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("upsertProducts", productIdParameter, nameParameter, categoryParameter, priceParameter, offerParameter);
        }
    
        public virtual int upsertVendors(string vendorId, string password, string name, string email, string address, string contact)
        {
            var vendorIdParameter = vendorId != null ?
                new ObjectParameter("vendorId", vendorId) :
                new ObjectParameter("vendorId", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var contactParameter = contact != null ?
                new ObjectParameter("contact", contact) :
                new ObjectParameter("contact", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("upsertVendors", vendorIdParameter, passwordParameter, nameParameter, emailParameter, addressParameter, contactParameter);
        }
    }
}
