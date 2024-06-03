using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Website_Library.Models.MetaData
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("SĐT không được để trống");
            }

            string phoneNumber = value.ToString();
            if (!Regex.IsMatch(phoneNumber, @"^\d+$"))
            {
                return new ValidationResult("Không được nhập ký tự");
            }

            return ValidationResult.Success;
        }
    }
}