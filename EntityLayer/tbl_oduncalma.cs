//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_oduncalma
    {
        public int VerilmeID { get; set; }
        public Nullable<int> Kitap { get; set; }
        public Nullable<int> Uye { get; set; }
        public Nullable<System.DateTime> VerilmeTarihi { get; set; }
        public string UyeTEL { get; set; }
        public string UyeMail { get; set; }
    
        public virtual tbl_kitap tbl_kitap { get; set; }
        public virtual tbl_uye tbl_uye { get; set; }
    }
}
