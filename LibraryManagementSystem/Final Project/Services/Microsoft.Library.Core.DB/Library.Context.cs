﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Library.Core.DB
{
    using System;
    using System.Data.Entity;
    using Microsoft.Library.Core.Model;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryDBContext : DbContext
    {
        public LibraryDBContext()
            : base("name=LibraryDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_Books> tbl_Books { get; set; }
        public DbSet<tbl_Category> tbl_Category { get; set; }
        public DbSet<tbl_Role> tbl_Role { get; set; }
        public DbSet<tbl_Transaction> tbl_Transaction { get; set; }
        public DbSet<tbl_Users> tbl_Users { get; set; }
    }
}
