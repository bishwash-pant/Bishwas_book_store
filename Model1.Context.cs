﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bishwas_book_store
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bishwash_tableEntities1 : DbContext
    {
        public bishwash_tableEntities1()
            : base("name=bishwash_tableEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category_table> category_tables { get; set; }
        public virtual DbSet<image_table> image_tables { get; set; }
        public virtual DbSet<order_details_table> order_details_tables { get; set; }
        public virtual DbSet<order_table> order_tables { get; set; }
        public virtual DbSet<product_table> product_tables { get; set; }
        public virtual DbSet<user_table> user_tables { get; set; }
    }
}