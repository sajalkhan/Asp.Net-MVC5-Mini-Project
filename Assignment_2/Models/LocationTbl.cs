//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LocationTbl
    {
        public LocationTbl()
        {
            this.EmployeeTbls = new HashSet<EmployeeTbl>();
        }
    
        public long LocationId { get; set; }
        public string LocationName { get; set; }
    
        public virtual ICollection<EmployeeTbl> EmployeeTbls { get; set; }
    }
}