using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(NXB.MetaData))]

    public partial class NXB
    {
        public int count { get; set; }

        sealed class MetaData
        {
            
            [DisplayName("Tên NXB")]
            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Tên NXB  không được để trống")]
            public string TenNXB { get; set; }
        }
    }
}