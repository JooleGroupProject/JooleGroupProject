//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleGroupProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSpecFilter
    {
        public int Property_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public string Min_value { get; set; }
        public string Max_value { get; set; }
    
        public virtual tblSubCategory tblSubCategory { get; set; }
    }
}
