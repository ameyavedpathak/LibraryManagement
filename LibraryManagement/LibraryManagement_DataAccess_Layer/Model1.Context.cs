﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement_DataAccess_Layer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryManagementEntities : DbContext
    {
        public LibraryManagementEntities()
            : base("name=LibraryManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
        public DbSet<LateFee> LateFees { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}