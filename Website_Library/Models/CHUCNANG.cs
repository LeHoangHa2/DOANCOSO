//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website_Library.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHUCNANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHUCNANG()
        {
            this.LOAI_TAIKHOAN = new HashSet<LOAI_TAIKHOAN>();
        }
    
        public string Ma_ChucNang { get; set; }
        public string Ten_ChucNang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOAI_TAIKHOAN> LOAI_TAIKHOAN { get; set; }
    }
}
