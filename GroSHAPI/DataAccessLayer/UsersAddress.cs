//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersAddress
    {
        public int id { get; set; }
        public Nullable<int> userid { get; set; }
        public string addressLine { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime modifiedDate { get; set; }
    
        public virtual UsersInfo UsersInfo { get; set; }
    }
}
