using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Library.Models.DAO
{
    public class PhieuMuon_DAO
    {

        public static string Create_PM()
        {
            using (Data_Entities db = new Data_Entities())
            {
                try
                {
                    // Get the last book ID from the database
                    string lastMaSach = db.PhieuMuons.OrderByDescending(n => n.MaPhieuMuon).Select(n => n.MaPhieuMuon).FirstOrDefault();

                    int newId = 1;
                    if (!string.IsNullOrEmpty(lastMaSach))
                    {
                        // Extract numeric part and parse it to get the last ID
                        string numericPart = lastMaSach.Substring(5); // Assuming "Sach_" prefix
                        int lastId;
                        if (int.TryParse(numericPart, out lastId))
                        {
                            newId = lastId + 1;
                        }
                    }

                    // Create the new book ID
                    string newMaSach = "PM_" + newId.ToString("D6");
                    return newMaSach;
                }
                catch (Exception ex)
                {
                    // Handle the exception or log it
                    return null;
                }
            }
        }
    }
}