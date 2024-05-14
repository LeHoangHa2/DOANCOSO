using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(ViTri.Metadata))]
    public partial class ViTri
    {
        sealed class Metadata
        {
            
            [DisplayName("Ngăn")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Ngăn  không được để trống")]
            public string Ngan { get; set; }
            [DisplayName("Kệ")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Kệ  không được để trống")]
            public string Ke { get; set; }
        }
    }
}