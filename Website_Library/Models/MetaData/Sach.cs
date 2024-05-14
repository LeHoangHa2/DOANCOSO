using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(Sach.Metadata))]
    public partial class Sach
    {
        public string ISBN { get; set; }
        public int count { get; set; }
        sealed class Metadata
        {
            [DisplayName("Tên Sách")]

            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "Tên không được để trống")]
            public string TenSach { get; set; }
            [DisplayName("Thể loại")]

            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "Mã loại sách không được để trống")]
            public string MaLoaiSach { get; set; }
            [DisplayName("Năm")]

            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "Năm không được để trống")]
            public Nullable<int> NamXB { get; set; }
            [DisplayName("Tên NXB")]

            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "Mã NXB không được để trống")]
            public string MaNXB { get; set; }
            [DisplayName("Số lượng")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Số lượng không được để trống")]
            [Range(0, double.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
            public Nullable<int> SoLuong { get; set; }
            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "Mã vị trí không được để trống")]
            [DisplayName("Vị trí")]

            public string MaViTri { get; set; }
            [DisplayName("Tên tác giả")]
            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "Tên tác giả không được để trống")]
            
            public string MaTacGia { get; set; }
            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "Ngôn Ngữ  không được để trống")]
            [DisplayName("Ngôn ngữ")]

            public string NgonNgu { get; set; }
            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "TimeCreate không được để trống")]
            [DisplayName("Thời gian tạo")]

            public Nullable<System.DateTime> TimeCreate { get; set; }
            [Required(AllowEmptyStrings = false,
                      ErrorMessage = "TimeUpdate không được để trống")]
            [DisplayName("Thời gian cập nhật")]

            public Nullable<System.DateTime> TimeUpdate { get; set; }
            
        }
    }
}