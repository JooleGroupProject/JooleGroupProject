//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleGroupProject.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProperty
    {
        public int Property_ID { get; set; }
        public string Property_Name { get; set; }
        public string IsType { get; set; }
        public string IsTechSpec { get; set; }
    
        public virtual tblPropertyValue tblPropertyValue { get; set; }
    }
}
