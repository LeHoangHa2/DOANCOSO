using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(TheLoai.Metadata))]
    public  partial class TheLoai
    {
        public int count { get; set; }
        sealed class Metadata
        {
            [DisplayName("Tên thể loại")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Tên thể loại không được để trống")]
            public string TenTheLoai { get; set; }
        }
    }
}