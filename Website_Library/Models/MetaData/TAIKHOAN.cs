using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Library.Models
{
    [MetadataType(typeof(TAIKHOAN.Metadata))]
    public partial class TAIKHOAN
    {
        public string url { get; set; }
        public bool Ghinho_Dangnhap { get; set; }
        public string New_Password { get; set; }
        public string Repeat_Password { get; set; }
        public string list_ChucNang { get; set; }
        public string Token {  get; set; }

        sealed class Metadata
        {

            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}