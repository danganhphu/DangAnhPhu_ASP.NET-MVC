//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThiGKDangAnhPhu_61134177.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CongNhan
    {
        public string MaCN { get; set; }
        public string HoCN { get; set; }
        public string TenCN { get; set; }
        public string AnhDaiDien { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public string MaTo { get; set; }
    
        public virtual ToQuanLy ToQuanLy { get; set; }
    }
}
