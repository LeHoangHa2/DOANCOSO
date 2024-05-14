using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(TacGia.Metadata))]
    public partial class TacGia
    {
        sealed class Metadata
        {
            
            [DisplayName("Tên tác giả")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Tên tác giả  không được để trống")]
            public string TenTacGia { get; set; }
        }
    }
}