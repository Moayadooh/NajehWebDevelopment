//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_DB_First.Models
{
    using System;
    
    public partial class sp_GetProperty_Result
    {
        public System.Guid PropertyID { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Bed { get; set; }
        public Nullable<int> Bath { get; set; }
        public Nullable<int> Typeid { get; set; }
        public Nullable<int> UserID { get; set; }
    }
}