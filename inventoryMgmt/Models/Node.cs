//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace inventoryMgmt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Node
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Node()
        {
            this.Project_Nodes_Allocation = new HashSet<Project_Nodes_Allocation>();
        }
    
        public string id { get; set; }
        public string rack_id { get; set; }
        public string ip { get; set; }
        public string originalHostName { get; set; }
        public string mac { get; set; }
        public string ipmi { get; set; }
        public string states { get; set; }
        public string comment { get; set; }
    
        public virtual Rack Rack { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project_Nodes_Allocation> Project_Nodes_Allocation { get; set; }
    }
}