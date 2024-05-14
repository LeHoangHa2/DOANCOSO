using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(PhieuMuon.Metadata))]
    public partial class PhieuMuon
    {
        public void UpdateTinhTrang()
        {
            if (NgayTraThucTe != null)
            {
                if (NgayTraThucTe > NgayTraDuKien)
                {
                    TinhTrang = "Quá hạn trả";
                }
                else
                {
                    TinhTrang = "Đã trả";
                }
            }
            else
            {
                TinhTrang = "Đang mượn";
            }
        }
        sealed class Metadata
        {
            [DisplayName("Họ Tên")]
            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Mã sinh viên  không được để trống")]
            public string MaSinhVien { get; set; }
            [DisplayName("Ngày mượn")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Ngày mượn  không được để trống")]
            public Nullable<System.DateTime> NgayMuon { get; set; }
            [DisplayName("Ngày trả")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Ngày trả dự kiến không được để trống")]
            public Nullable<System.DateTime> NgayTraDuKien { get; set; }
            [DisplayName("Ngày trả TT")]

        
            public Nullable<System.DateTime> NgayTraThucTe { get; set; }

   
            public string TinhTrang { get; set; }
            [DisplayName("Ghi chú")]

            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Ghi chú không được để trống")]
            public string GhiChu { get; set; }
            [DisplayName("Tên Sách")]
            [Required(AllowEmptyStrings = false,
                     ErrorMessage = "Sách  không được để trống")]
            public string MaSach { get; set; }
        }
    }
}