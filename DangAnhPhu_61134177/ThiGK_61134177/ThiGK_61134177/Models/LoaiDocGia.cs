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
    using System.Collections.Generic;
    
    public partial class LoaiDocGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiDocGia()
        {
            this.DocGia = new HashSet<DocGia>();
        }
    
        public string MaLoaiDocGia { get; set; }
        public string TenLoaiDocGia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocGia> DocGia { get; set; }
    }
}