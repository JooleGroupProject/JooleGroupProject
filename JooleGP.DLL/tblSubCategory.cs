//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleGP.DLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSubCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSubCategory()
        {
            this.tblProducts = new HashSet<tblProduct>();
            this.tblSpecFilters = new HashSet<tblSpecFilter>();
            this.tblTypeFilters = new HashSet<tblTypeFilter>();
        }
    
        public int SubCategory_ID { get; set; }
        public int Category_ID { get; set; }
        public string SubCategory_Name { get; set; }
    
        public virtual tblCategory tblCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSpecFilter> tblSpecFilters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTypeFilter> tblTypeFilters { get; set; }
    }
}
