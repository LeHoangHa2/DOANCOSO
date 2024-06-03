using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Website_Library.Models.MetaData;

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
            [DisplayName("SĐT")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "SĐT không được để trống")]
            [PhoneNumber(ErrorMessage = "Không được nhập ký tự")]
            public string DienThoai { get; set; }
            [DisplayName("Địa chỉ")]

            [Required(AllowEmptyStrings = false,
                    ErrorMessage = "Địa chỉ  không được để trống")]
            public string DiaChi { get; set; }
        }
    }
}