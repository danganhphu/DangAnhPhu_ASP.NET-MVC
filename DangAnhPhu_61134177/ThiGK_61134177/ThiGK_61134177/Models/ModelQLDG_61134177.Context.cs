//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThiGK_61134177.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ThiGK_61134177Entities : DbContext
    {
        public ThiGK_61134177Entities()
            : base("name=ThiGK_61134177Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DocGia> DocGia { get; set; }
        public virtual DbSet<LoaiDocGia> LoaiDocGia { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
