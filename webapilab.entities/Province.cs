//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webapilab.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Province
    {
        public Province()
        {
            this.Towns = new HashSet<Town>();
        }
    
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public int CommunityId { get; set; }
    
        public virtual Community Community { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
