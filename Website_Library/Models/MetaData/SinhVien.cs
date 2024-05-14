using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(SinhVien.Metadata))]
    public partial class SinhVien
    {
        public string Repeat_Password { get; set; }
        public string url { get; set; }
        public string list_ChucNang { get; set; }
        public string Token { get; set; }

        sealed class Metadata
        {
           
            [DisplayName("Tên sinh viên")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Tên sinh viên  không được để trống")]
            public string TenSinhVien { get; set; }
            [DisplayName("Ngày sinh")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Ngày không được để trống")]
            public Nullable<System.DateTime> NgaySinh { get; set; }
            [DisplayName("Giới tính")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Giới tính  không được để trống")]
            public string GioiTinh { get; set; }
            [DisplayName("Địa chỉ")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Địa chỉ  không được để trống")]
            public string DiaChi { get; set; }
            [DisplayName("SĐT")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "SĐT không được để trống")]
            [Range(0, Int32.MaxValue, ErrorMessage = "Không được nhập ký tự")]
            public string DienThoai { get; set; }
            [DisplayName("Tài khoản")]

            [Required(AllowEmptyStrings = false,
                                 ErrorMessage = "Tài khoản  không được để trống")]
            public string TaiKhoan { get; set; }
            [DisplayName("Mật khẩu")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Mật khẩu  không được để trống")]
            public string MatKhau { get; set; }
            [DisplayName("Email")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Email  không được để trống")]
            public string Email { get; set; }
        }
    }
}
