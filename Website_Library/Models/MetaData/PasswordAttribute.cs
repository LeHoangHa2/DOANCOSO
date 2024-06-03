using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Website_Library.Models.MetaData
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Mật khẩu không được để trống");
            }

            string password = value.ToString();

            // Kiểm tra độ dài
            if (password.Length < 8)
            {
                return new ValidationResult("Mật khẩu phải có ít nhất 8 ký tự");
            }

            // Kiểm tra ký tự chữ hoa
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return new ValidationResult("Mật khẩu phải chứa ít nhất một chữ hoa");
            }

            // Kiểm tra ký tự đặc biệt
            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]"))
            {
                return new ValidationResult("Mật khẩu phải chứa ít nhất một ký tự đặc biệt");
            }

            return ValidationResult.Success;
        }
    }
}